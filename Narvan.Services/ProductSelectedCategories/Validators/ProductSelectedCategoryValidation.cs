using FluentValidation;
using Narvan.Domains.ProductSelectedCategories.Entities;

namespace Narvan.Services.ProductSelectedCategories.Validators
{
    public class ProductSelectedCategoryValidation:AbstractValidator<ProductSelectedCategory>
    {
        public ProductSelectedCategoryValidation()
        {
         
        }
    }
}