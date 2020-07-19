using FluentValidation;
using Narvan.Domains.Roles.Entities;

namespace Narvan.Services.Roles.Validators
{
    public class RoleValidation:AbstractValidator<Role>
    {
        public RoleValidation()
        {
            RuleFor(r=>r.Name).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(100).WithMessage("{PropertyName} حداکثر 100 کاراکتر می باشد.")
                .WithMessage("نام سیستمی");

            RuleFor(r => r.Title).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(100).WithMessage("{PropertyName} حداکثر 100 کاراکتر می باشد.")
                .WithMessage("عنوان ");
        }
    }
}