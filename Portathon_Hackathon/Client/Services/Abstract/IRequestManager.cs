using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Client.Services.Abstract
{
    public interface IRequestManager
    {
        Task<ServiceResponse<RequestDTO>> MakeRequest(RequestDTO dto);
        Task<ServiceResponse<RequestDTO>> UpdateYourRequest(int updateId,RequestDTO dto);
        Task<ServiceResponse<string>> DeleteRequest(int requestId);
        Task<ServiceResponse<List<RequestDTO>>> GetAllRequestByUserId(int userId);
        Task<ServiceResponse<List<Request>>> GetAllRequestForCompany(int companyId);
    }
}
