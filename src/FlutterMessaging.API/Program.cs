using System.Text;
using FlutterMessaging.ClientAPI.ServiceExtensions;
using FlutterMessaging.Logic.ServiceExtensions;
using FlutterMessaging.Logic.ServiceLogic;
using FlutterMessaging.State.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using DotNetEnv;
using FlutterMessaging.DTO.Types;
using FlutterMessaging.State.Base.dbContext;

namespace FlutterMessagingApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Env.Load();
            var builder = WebApplication.CreateBuilder(args);

            Uri baseAddress = new("http://localhost:5064/");

            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));

            //JWT
            if (string.IsNullOrWhiteSpace(builder.Configuration["Jwt:SigningKey"]))
                throw new ArgumentNullException("Failed to find Jwt:SigningKey in .env");

            builder.Services.Configure<RefreshTokenOptions>(builder.Configuration.GetSection("RefreshToken"));
            builder.Services.AddSingleton<IRefreshTokenService, RefreshTokenService>();

            string? pepper = builder.Configuration["RefreshToken:Pepper"];
            if (string.IsNullOrWhiteSpace(pepper))
                Console.WriteLine("RefreshToken pepper not set; using SHA-256 fallback (dev only)."); 

            byte[] signingKeyBytes = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SigningKey"]);  

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(signingKeyBytes);

            builder.Services.AddSingleton(new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));
            builder.Services.AddSingleton<ITokenIssuer, JwtTokenIssuer>();

            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = securityKey,
                        RequireSignedTokens = true,
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromSeconds(30)
                    };
                }); 


            // Add services to the container. 
            builder.Services.AddControllers();

            //dbContext EFCore
            builder.Services.AddDbContext<MessagingDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("Local"))
                        .UseSnakeCaseNamingConvention());

            //Extensions
            builder.Services.AddRepositories();
            builder.Services.AddLogic();
            builder.Services.AddClientApiExtensions(baseAddress);

            builder.Services.AddAuthorization();


            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();  

            app.MapControllers();

            app.Run();
        }
    }
}
