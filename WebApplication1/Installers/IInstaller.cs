using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Post_Surfer
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection serviceCollection ,IConfiguration configuration);
    }
}
