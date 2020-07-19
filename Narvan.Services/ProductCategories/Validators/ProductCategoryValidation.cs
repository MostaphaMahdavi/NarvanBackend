using FluentValidation;
using Narvan.Domains.ProductCategories.Entities;

namespace Narvan.Services.ProductCategories.Validators
{
    public class ProductCategoryValidation:AbstractValidator<ProductCategory>
    {
        public ProductCategoryValidation()
        {
            RuleFor(c=>c.Title).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(250).WithMessage("{PropertyName} حداکثر 250 کاراکتر می باشد")
                .WithName("عنوان");

            RuleFor(c => c.UrlTitle).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(250).WithMessage("{PropertyName} حداکثر 250 کاراکتر می باشد")
                .WithName("آدرس");
        }
    }
}