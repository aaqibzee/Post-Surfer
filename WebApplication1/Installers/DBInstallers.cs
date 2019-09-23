using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Post_Surfer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Post_Surfer.Services;

namespace Post_Surfer.Installers
{
    public class DBInstallers : Installer
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddScoped<IPostService, PostService>();

        }
    }
}
