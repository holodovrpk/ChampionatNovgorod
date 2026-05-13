using Champ.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Champ.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<JobContext>(options =>
                    options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
                  Database=JobDb;
                  Trusted_Connection=True;
                  TrustServerCertificate=True;"));


            // Секретный ключ для создания и проверки JWT токенов
            string jwtKey = "12345678901234567890123456789012";

            // Подключаем JWT авторизацию
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

                // Настройка проверки JWT токена
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        // Для простого варианта НЕ проверяем издателя токена
                        ValidateIssuer = false,

                        // Для простого варианта НЕ проверяем получателя токена
                        ValidateAudience = false,

                        // Пока НЕ проверяем срок действия
                        ValidateLifetime = false,

                        // Проверяем только подпись
                        ValidateIssuerSigningKey = true,

                        // Наш секретный ключ
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(jwtKey))
                    };
                });

            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
