using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;

namespace Portathon_Hackathon.Client.Services.Abstract
{
    public interface IRequestManager
    {
        Task<ServiceResponse<RequestDTO>> MakeRequest(RequestDTO dto);
        Task<ServiceResponse<RequestDTO>> UpdateYourRequest(int updateId,RequestDTO dto);
        Task<ServiceResponse<string>> DeleteRequest(int requestId);
        Task<ServiceResponse<List<RequestDTO>>> GetAllRequestByUserId(int userId);
    }
}
