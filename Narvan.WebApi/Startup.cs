using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Narvan.DataAccessCommands.Context;
using Serilog;
using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Narvan.WebApi.Utilities.Extentions.Iocs;
using Narvan.WebApi.Utilities.Extentions.Validations;

namespace Narvan.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            HostEnvironment = hostEnvironment;

            #region SeriLog

            Log.Logger = new LoggerConfiguration()

                .ReadFrom.Configuration(Configuration)
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
            #endregion
        }

        public IConfiguration Configuration { get; }
        public IHostEnvironment HostEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();




            #region Cors

            services.AddCors(option =>
            {
                option.AddPolicy(name: "Default", builder =>
                 {
                     builder.AllowAnyHeader();
                     builder.AllowAnyMethod();
                     builder.AllowAnyOrigin();


                     //   builder.WithOrigins("http://localhost:4200/");
                 });
            });

            #endregion

            #region DbContext

            services.AddDbContext<NarvanContext>(options =>
                { options.UseSqlServer(Configuration["ConnectionStrings:CommandConnection"]); });

            #endregion

            #region Mapper

            services.AddAutoMapper(typeof(Startup));

            #endregion

            #region Authentication


            services.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"]

                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });


            services.AddMvc();

            #endregion

            #region MediatR

            var assembly = AppDomain.CurrentDomain.Load("Narvan.Services");
            services.AddMediatR(assembly);

            #endregion

            #region Validator

            services.AddValidation();

            #endregion

            #region IOC

            services.AddIoc();

            #endregion

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Narvan API", Version = "v1" });
            }); 
            
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStatusCodePages();

            #region Swagger
            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Narvan");

            });


            #endregion




            app.UseRouting();


            app.UseCors("Default");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{Controller=Users}/{Action=Index}/{Id?}"

                    );
            });
        }
    }
}
