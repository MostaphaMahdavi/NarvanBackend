using FluentValidation;
using Narvan.Domains.Products.Entities;

namespace Narvan.Services.Products.Validators
{
    public class ProductValidation:AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(p=>p.ImageName).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .WithName("تصویر");

            RuleFor(p=>p.ProductName).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(250).WithMessage("{PropertyName} حداکثر 250 کاراکتر می باشد")
                .WithName("نام محصول");

            RuleFor(p => p.ShortDescription).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(700).WithMessage("{PropertyName} حداکثر 700 کاراکتر می باشد")
                .WithName("توضیحات مختصر");

            RuleFor(p => p.Description).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(3900).WithMessage("{PropertyName} حداکثر 250 کاراکتر می باشد")
                .WithName("توضیحات");




        }
    }
}