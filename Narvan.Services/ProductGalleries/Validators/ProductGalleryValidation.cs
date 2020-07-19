using FluentValidation;
using Narvan.Domains.ProductGalleries.Entities;

namespace Narvan.Services.ProductGalleries.Validators
{
    public class ProductGalleryValidation:AbstractValidator<ProductGallery>
    {
        public ProductGalleryValidation()
        {
            RuleFor(pg=>pg.ImageName).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .WithName("تصویر");

 

        }
    }
}