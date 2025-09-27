//using Microsoft.EntityFrameworkCore;

using FlutterMessaging.State.Data;
using Microsoft.EntityFrameworkCore;

namespace FlutterMessagingApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //dbContext EFCore
            builder.Services.AddDbContext<MessagingDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("Local")));


            var app = builder.Build();


            
                
             

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
