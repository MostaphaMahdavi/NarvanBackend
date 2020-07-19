using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Narvan.Domains.Roles.Entities;
using Narvan.Domains.Users.Commands;
using Narvan.Domains.Users.Entities;
using Narvan.Domains.Users.Enums;
using Narvan.Services.PipelineBehaviors;
using Narvan.Services.Roles.Validators;
using Narvan.Services.Users.Commands.Behaviors;
using Narvan.Services.Users.Validators;

namespace Narvan.WebApi.Utilities.Extentions.Validations
{
    public static class ValidationExtention
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ErrorHandlingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<RegisterUserInfo, RegisterUserResult>), typeof(EmailExistBehavior<RegisterUserInfo, RegisterUserResult>));
            // services.AddTransient(typeof(IPipelineBehavior<ActiveUserInfo,ResultStatusType>),typeof(UserExistByActiveCodeBehavior<ActiveUserInfo, RegisterUserResult>));


            services.AddTransient<IValidator<User>, UserValidation>();
            services.AddTransient<IValidator<Role>, RoleValidation>();
            services.AddTransient<IValidator<AddUserCommandInfo>, AddUserCommandInfoValidation>();
            services.AddTransient<IValidator<RegisterUserInfo>, RegisterUserInfoValidation>();


            return services;
        }
    }
}