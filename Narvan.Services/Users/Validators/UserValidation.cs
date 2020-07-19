using FluentValidation;
using Narvan.Domains.Users.Entities;

namespace Narvan.Services.Users.Validators
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {

            RuleFor(u => u.FirstName).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(250).WithMessage("{PropertyName} حداکثر 250 کاراکتر می باشد")
                .WithName("نام");

            RuleFor(u => u.LastName).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(250).WithMessage("{PropertyName} حداکثر 250 کاراکتر می باشد")
                .WithName("نام خانوادگی");

            RuleFor(u => u.Email).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(250).WithMessage("{PropertyName} حداکثر 250 کاراکتر می باشد")
                .EmailAddress().WithMessage("فرمت ایمیل وارد نمایید.")
                .WithName("ایمیل");

            RuleFor(u => u.Address).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(500).WithMessage("{PropertyName} حداکثر 500 کاراکتر می باشد")
                .WithName("آدرس");

            RuleFor(u => u.Password).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(50).WithMessage("{PropertyName} حداکثر 50 کاراکتر می باشد")
                .WithName("کلمه عبور");
        }
    }
}