using MediatR;
using Microsoft.AspNetCore.Mvc;
using Narvan.Domains.Enums;
using Narvan.Domains.Users.Commands;
using Narvan.Domains.Users.Queries;
using System.Threading.Tasks;
using Narvan.Domains.Users.Entities;

namespace Narvan.WebApi.Controllers
{

    public class UsersController : BaseController
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllUserInfo());

            return Ok(result);
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> Get(long id)
        {
            var result = await _mediator.Send(new GetUserByIdInfo(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddUserCommandInfo user)
        {
            var result = await _mediator.Send(user);
            switch (result)
            {
                case ResultStatusType.Success:
                    return Success(user);
                case ResultStatusType.Error:
                    return Error(user);
                default:
                    return Error();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(EditUserCommandInfo user)
        {
            var result = await _mediator.Send(user);
            switch (result)
            {
                case ResultStatusType.Success:
                    return Success(user);
                case ResultStatusType.Error:
                    return Error(user);
                default:
                    return Error();
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteUserByIdInfo(id));
            switch (result)
            {
                case ResultStatusType.Success:
                    return Success(id);
                case ResultStatusType.Error:
                    return Error(id);
                default:
                    return Error();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(User user)
        {
            var userId = user.Id;
            return await Delete(userId);

        }



    }
}
