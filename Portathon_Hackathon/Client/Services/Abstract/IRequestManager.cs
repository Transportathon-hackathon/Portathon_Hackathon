using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;

namespace Portathon_Hackathon.Client.Services.Abstract
{
    public interface IRequestManager
    {
        Task<ServiceResponse<RequestDTO>> MakeRequest(RequestDTO dto);
        Task<ServiceResponse<RequestDTO>> UpdateYourRequest(int updateId,RequestDTO model);
        Task<ServiceResponse<string>> DeleteRequest(int updateId);
    }
}
