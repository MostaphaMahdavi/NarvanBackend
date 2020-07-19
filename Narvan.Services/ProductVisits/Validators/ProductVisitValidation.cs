using FluentValidation;
using Narvan.Domains.ProductVisits.Entities;

namespace Narvan.Services.ProductVisits.Validators
{
    public class ProductVisitValidation:AbstractValidator<ProductVisit>
    {
        public ProductVisitValidation()
        {
            

            RuleFor(p=>p.UserIp).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(100).WithMessage("{PropertyName} حداکثر 250 کاراکتر می باشد")
                .WithName("ای پی");
        }
    }
}