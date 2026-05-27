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


         

            builder.Services.AddCors();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseHttpsRedirection();



            app.MapControllers();

            app.Run();
        }
    }
}
