using Portathon_Hackathon.Shared.Model;
using Portathon_Hackathon.Shared;

namespace Portathon_Hackathon.Client.Services.Abstract
{
    public interface IAuthManager
    {
        //Task<ServiceResponse<int>> Register(UserRegister request);
        Task<ServiceResponse<string>> Login(UserLogin user);
        Task<ServiceResponse<int>> CreateUser(UserRegister registerModel);
        Task<bool> IsUserAuthenticated();
        Task Logout();
    }
}
