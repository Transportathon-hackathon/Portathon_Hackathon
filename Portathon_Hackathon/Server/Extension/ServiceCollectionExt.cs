using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Server.Services.Concrete;

namespace Portathon_Hackathon.Server.Extension
{
    public static class ServiceCollectionExt
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<ICrewMemberService, CrewMemberService>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IEvaluationService, EValuationService>();

            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IMessageService, MessageService>();
            return services;
        }

        public static IServiceCollection AddPersistenceLayerIdentityExt(this IServiceCollection services, IConfiguration configuration)
        {
                    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(System.Text.Encoding.UTF8
                        .GetBytes(configuration.GetSection("AppSettings:SecretKey").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }

        public static IServiceCollection AddPersistenceSwaggerExt(this IServiceCollection services, IConfiguration configuration)
        {
                            services.AddSwaggerGen(c =>
                            {

                                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                                {
                                    Name = "Authorization",
                                    Type = SecuritySchemeType.ApiKey,
                                    Scheme = "Bearer",
                                    BearerFormat = "JWT",
                                    In = ParameterLocation.Header,
                                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                                });
                                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                        {
                            new OpenApiSecurityScheme {
                                Reference = new OpenApiReference {
                                    Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                }
                            },
                            new string[] {}
                        }
                    });
                            });
            return services;
        }

    }
}
