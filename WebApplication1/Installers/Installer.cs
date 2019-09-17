using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Post_Surfer
{
    public interface Installer
    {
        void InstallServices(IServiceCollection serviceCollection ,IConfiguration configuration);
    }
}
