using InstantMessaging_IM.Application.Common.Contracts;
using InstantMessaging_IM.Domain.Identity;
using InstantMessaging_IM.Infrastructure.Persistence;
using InstantMessaging_IM.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace InstantMessaging_IM.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();

            if (configuration.GetSection("UseInMemoryDatabase").Get<bool>())
            {
                services.AddDbContext<IdentityDbContext>(options =>
                    options.UseInMemoryDatabase("IdentityDbContext")
                );
                services.AddDbContext<InstantMessagingDbContext>(options =>
                    options.UseInMemoryDatabase("InstantMessagingDbContext")
                );
            }
            else
            {
                services.AddDbContext<IdentityDbContext>(options =>
                   options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(IdentityDbContext).Assembly.FullName)
                   ).UseSnakeCaseNamingConvention());

                services.AddDbContext<InstantMessagingDbContext>(options =>
                   options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(InstantMessagingDbContext).Assembly.FullName)
                   ).UseSnakeCaseNamingConvention());

            }
            services.AddScoped<IIdentityDbContext, IdentityDbContext>();
            services.AddScoped<ApplicationUserManagerBase, ApplicationUserManager>();
            services.AddScoped<IInstantMessagingDbContext, InstantMessagingDbContext>();

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            })
        .AddUserManager<ApplicationUserManager>()
        .AddEntityFrameworkStores<IdentityDbContext>()
        .AddDefaultTokenProviders();

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            //}).AddJwtBearer(options =>
            //{
            //    options.SaveToken = true;
            //    options.RequireHttpsMetadata = false;
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidAudience = configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>().Audience,
            //        ValidIssuer = configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>().Issuer,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>().Secret)),
            //        SaveSigninToken = true,

            //    };
            //});

            return services;
        }
    }
}
