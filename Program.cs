using Amazon.Runtime;
using Amazon.S3;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RetailEcommerce.Domain.Models;
using RetailEcommerce.Infrastructure.Data;
using RetailEcommerce.Services.Interfaces;
using RetailEcommerce.Services;
using Scalar.AspNetCore;
using System.Text;
using Serilog;

namespace RetailEcommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure Serilog

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
                .Enrich.FromLogContext()
                .CreateLogger();

            //builder.Host.UseSerilog(); 

            builder.Services.AddControllers();

            //CORS Configuration
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials();
                });
            });

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

            builder.Services.AddScoped<ICloudService, AwsService>();

            builder.Services.AddSingleton<AWSCredentials>(sp =>
                new BasicAWSCredentials(
                    builder.Configuration["AWS:AccessKey"],
                    builder.Configuration["AWS:SecretKey"]
                )
            );
            builder.Services.AddSingleton<IAmazonS3>(sp =>
                new AmazonS3Client(
                    sp.GetRequiredService<AWSCredentials>(),
                    Amazon.RegionEndpoint.GetBySystemName(builder.Configuration["AWS:Region"])
                )
            );

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapScalarApiReference();
            }

            app.UseRouting();
            app.UseCors("AllowAngularApp");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
