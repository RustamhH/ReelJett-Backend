using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using ReelJett.Infrastructure.Hubs;
using ReelJett.Application.Services;
using Microsoft.IdentityModel.Tokens;
using ReelJett.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using ReelJett.Infrastructure.BackgroundServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;

namespace ReelJett.Infrastructure;

public static class RegisterServices {
    public static void AddInfrastructureRegister(this WebApplicationBuilder builder) {

        // Dependancy Injection

        builder.Services.AddTransient<NotificationHub>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IEmailService, EmailService>();
        builder.Services.AddHostedService<MoviePublishCheckService>();
        builder.Services.AddScoped<IScrapingService, ScrapingService>();

        // Add Auth JWT

        builder.Services.ConfigureApplicationCookie(options => {
            options.Cookie.HttpOnly = true;
            options.Cookie.SameSite = SameSiteMode.None;
        });

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters() {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    LifetimeValidator = (before, expires, token, param) => expires > DateTime.UtcNow,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]!))
                };
            });
    }
}
