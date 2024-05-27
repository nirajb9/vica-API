using _365Insurance.Core.Domain.Models;
using _365Insurance.Services.IServices;
using _365Insurance.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.Text;

namespace _365insuranceAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }
        public IDbConnection DbConnection { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Insure247DbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("365IConnection")));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            services.AddScoped<IVehicleInfoService, VehicleInfoService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IVehicleCubicCapicityService, VehicleCubicCapicityService>();
            services.AddScoped<IVehicleModelService, VehicleModelService>();
            services.AddScoped<IVehicleVariantService, VehicleVariantService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ITPRequestQuotationService, TPRequestQuotationService>();
            services.AddScoped<IStateService, StateService>();
            services.AddControllers();
        }
    }
}
