using FluentValidation;
using Narvan.Domains.Users.Queries;

namespace Narvan.Services.Users.Validators
{
    public class LoginUserInfoQueryValidation:AbstractValidator<LoginUserInfoQuery>
    {
        public LoginUserInfoQueryValidation()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(250).WithMessage("{PropertyName} حداکثر 250 کاراکتر می باشد")
                .EmailAddress().WithMessage("فرمت ایمیل وارد نمایید.")
                .WithName("ایمیل");


            RuleFor(u => u.Password).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(50).WithMessage("{PropertyName} حداکثر 50 کاراکتر می باشد")
                .WithName("کلمه عبور");
        }
    }
}