using ReelJett.WebAPI;
using ReelJett.Persistence;
using ReelJett.Infrastructure;
using Microsoft.OpenApi.Models;
using ReelJett.Infrastructure.Hubs;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.AddInfrastructureRegister();
builder.Services.AddPersistenceRegister();
builder.Services.AddIdentityConfigureServices();
builder.Services.AddCors(options => {

    options.AddPolicy("CorsPolicy", builder => {
        builder.WithOrigins("https://localhost:5173") // Local frontend URL
               .WithOrigins("https://reeljett.com") // Your frontend URL
               .WithOrigins("http://localhost:5173") // Local frontend URL
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});
builder.Services.AddSignalR();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//// Swagger Auth Options
//builder.Services.AddSwaggerGen(option => {

//    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
//    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
//        In = ParameterLocation.Header,
//        Description = "Please enter a valid token",
//        Name = "Authorization",
//        Type = SecuritySchemeType.Http,
//        BearerFormat = "JWT",
//        Scheme = "Bearer"
//    });

//    option.AddSecurityRequirement(new OpenApiSecurityRequirement {
//        { new OpenApiSecurityScheme {
//                Reference = new OpenApiReference {
//                    Type=ReferenceType.SecurityScheme,
//                    Id="Bearer"
//                }
//            },
//            new string[]{}
//        }
//    });
//});

var app = builder.Build();

app.Services.AddRoleServices();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints((endpoints) => {
    endpoints.MapControllers().RequireCors("CorsPolicy");
    endpoints.MapHub<NotificationHub>("/notificationHub").RequireCors("CorsPolicy");
});

app.Run();