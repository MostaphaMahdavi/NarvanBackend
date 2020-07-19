using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Narvan.Domains.Commons.Securities;
using Narvan.Domains.Users.Commands;
using Narvan.Domains.Users.Enums;
using Narvan.Domains.Users.Queries;
using Narvan.WebApi.Utilities.Convertors;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Narvan.Domains.Commons;
using Narvan.Domains.Enums;
using Narvan.Services.Commons.MailSenders;
using Narvan.WebApi.Utilities.Extentions.Identities;

namespace Narvan.WebApi.Controllers
{

    public class AccountController : BaseController
    {
        #region Constructor

        private readonly IMediator _mediator;
        private readonly IPasswordHelper _passwordHelper;
        private readonly IConfiguration _configuration;
        private readonly IViewRenderService _viewRenderService;


        public AccountController(IMediator mediator, IPasswordHelper passwordHelper, IConfiguration configuration, IViewRenderService viewRenderService)
        {
            _mediator = mediator;
            _passwordHelper = passwordHelper;
            _configuration = configuration;
            _viewRenderService = viewRenderService;
        }

        #endregion

        #region Register

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(RegisterUserInfo userInfo)
        {
            userInfo.EmailActiveCode = Generator.GenerateGuid();
            var result = await _mediator.Send(userInfo);


            switch (result)
            {
                case RegisterUserResult.EmailExists:
                    return Error(new { info = "Email Exists" });
                case RegisterUserResult.Success:
                    {

                        #region Send Activation Email

                        string body = await _viewRenderService.RenderToStringAsync("Emails/_activateAccount", userInfo);
                        SendEmail.Send(userInfo.Email, "ایمیل فعالسازی", body,
                            _configuration["MailSender:Smtp"],
                            _configuration["MailSender:Email"],
                            _configuration["MailSender:title"],
                            int.Parse(_configuration["MailSender:port"]),
                            _configuration["MailSender:Password"]);

                        #endregion
                        return Success(userInfo);

                    }

            }



            return Error(new { info = "error" });
        }


        #endregion

        #region Login
        [HttpPost("LogIn")]
        public async Task<IActionResult> Login(LoginUserInfoQuery loginInfo)
        {
            loginInfo.Password = _passwordHelper.EncodePasswordMd5(loginInfo.Password);
            var user = await _mediator.Send(loginInfo);

            if (user == null)
            {
                return NotFound(new { info = "کاربری یافت نشد" });

            }
            else if (user.IsActivated == false)
            {
                return Error(new { info = "حساب کاربری شما فعال نشده است" });
            }
            else
            {

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Issuer"],
                    claims: new List<Claim>
                    {

                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Role,"User"),
                        new Claim("FullName",user.FirstName+' '+user.LastName)
                    },
                    expires: loginInfo.RememberMe ? DateTime.Now.AddDays(30) : DateTime.Now.AddMinutes(3),
                    // expires: DateTime.Now.AddDays(30),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);


                return Success(new { token = tokenString, expireTime = loginInfo.RememberMe ? 30 : 3, firstName = user.FirstName, lastName = user.LastName, userId = user.Id, email = user.Email, address = user.Address });



            }


        }


        #endregion

        #region Check User Authentication

        [HttpPost("CheckUserAuthentication")]
        public async Task<IActionResult> CheckAuthentication()
        {


            if (User.Identity.IsAuthenticated)
            {

                var res = await _mediator.Send(new GetUserByIdInfo(User.GetUserId()));

                return Success(new { userId = res.Id, firstName = res.FirstName, lastName = res.LastName, email = res.Email, address = res.Address });
            }

            return Error();

        }

        #endregion

        #region activeUser
        [HttpGet("ActiveUser/{id}")]
        public async Task<IActionResult> ActiveUser(string id)
        {
            var request = await _mediator.Send(new ActiveUserInfo(id));

            switch (request)
            {
                case ResultStatusType.Success:
                    return Success();
                case ResultStatusType.Error:
                    return Error();
                case ResultStatusType.NotActivated:
                    return NotFound();
            }


            return Error(new { info = "[خطای ناشناخته ای رخ داده است" });
        }

        #endregion

        #region SignOut

        [HttpGet("SignOut")]
        public async Task<IActionResult> LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
                return Success();
            }

            return Error();
        }

        #endregion


    }




}
