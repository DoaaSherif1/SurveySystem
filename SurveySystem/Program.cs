
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SurveySystem.DAL.Data.Context;
using System.Text;

namespace SurveySystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Context

            // connection string in UserSecrets.
            var connectionString = builder.Configuration.GetConnectionString("kpis_ConString");
            builder.Services.AddDbContext<KPISContext>(options =>
                options.UseSqlServer(connectionString)); //registered as scoped

            #endregion

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Cool";
                options.DefaultChallengeScheme = "Cool";
            })
               .AddJwtBearer("Cool", options =>
               {
                   string keyString = builder.Configuration.GetValue<string>("SecretKey") ?? string.Empty;
                   var keyInBytes = Encoding.ASCII.GetBytes(keyString);
                   var key = new SymmetricSecurityKey(keyInBytes);

                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       IssuerSigningKey = key,
                       ValidateIssuer = false,
                       ValidateAudience = false,
                   };
               });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}