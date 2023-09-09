using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Services.Abstract
{
    public interface IUserService
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<ServiceResponse<bool>> SelectAdmin(string email);
        int GetUserId();
        string GetUserEmail();
    }
}
