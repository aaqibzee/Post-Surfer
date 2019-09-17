using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1;
namespace WebApplication1.Installers
{
    public static class InstallerExtensions
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>
           typeof(Installer).IsAssignableFrom(x) && !x.IsInterface).Select(Activator.CreateInstance).Cast<Installer>().ToList();
            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}
