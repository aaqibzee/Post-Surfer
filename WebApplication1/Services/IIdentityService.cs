using Microsoft.AspNetCore.Mvc;
using Post_Surfer.Domain;
using System.Threading.Tasks;

namespace Post_Surfer.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
        Task<AuthenticationResult> LoginAsync(string email, string password);
    }
}
