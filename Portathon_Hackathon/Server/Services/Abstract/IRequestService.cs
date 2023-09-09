using Microsoft.Exchange.WebServices.Data;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Services.Abstract
{
    public interface IRequestService
    {
        Task<ServiceResponse<RequestDTO>> CreateRequest(int userId,RequestDTO request);
        Task<ServiceResponse<List<RequestDTO>>> GetAllRequest(int userId);

        Task<ServiceResponse<RequestDTO>> GetRequest(int requestId);
        Task<ServiceResponse<string>> DeleteRequest(int requestId);
    }
}
