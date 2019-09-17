using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public interface Installer
    {
        void InstallServices(IServiceCollection serviceCollection ,IConfiguration configuration);
    }
}
