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

namespace RetailEcommerce.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();

            //CORS Configuration
            builder.Services.AddCors(options =>
            {
                //https://legacy-estates.co
                options.AddPolicy("AllowAngularApp", policy =>
                {
                    policy.WithOrigins("http://localhost:4200") // Explicitly allow Angular frontend
                          .AllowAnyMethod()                    // Allow GET, POST, OPTIONS, etc.
                          .AllowAnyHeader()                    // Allow Authorization, Content-Type, etc.
                          .AllowCredentials();                 // Support credentialed requests
                });
            });
            
            
            //add dbcontext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            
            
            
            //add identity
            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            
            
            
            // Configure Authentication using JSON web Token
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



            //AWS S3 Service
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
            
            
            
            //Projects Injection


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
