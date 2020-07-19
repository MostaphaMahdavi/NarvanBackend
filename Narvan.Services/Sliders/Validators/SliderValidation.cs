using FluentValidation;
using Narvan.Domains.Sliders.Entities;

namespace Narvan.Services.Sliders.Validators
{
    public class SliderValidation:AbstractValidator<Slider>
    {
        public SliderValidation()
        {
            RuleFor(s=>s.Title).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(100).WithMessage("{PropertyName} حداکثر 250 کاراکتر می باشد")
                .WithName("عنوان");

            RuleFor(s => s.Description).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
                .MaximumLength(1000).WithMessage("{PropertyName} حداکثر 1000 کاراکتر می باشد")
                .WithName("توضیحات");

            RuleFor(s => s.Description).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد")
              
                .WithName("تصویر");

            RuleFor(s => s.Link)
                .MaximumLength(150).WithMessage("{PropertyName} حداکثر 250 کاراکتر می باشد")
                .WithName("لینک");

        }
    }
}