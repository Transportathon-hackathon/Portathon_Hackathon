
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Services.Abstract
{
    public interface IRequestService
    {
        public Task<ServiceResponse<RequestDTO>> CreateRequest(int userId, RequestDTO requestDto);
        public Task<ServiceResponse<string>> DeleteRequest(int requestId);
        public Task<ServiceResponse<List<RequestDTO>>> GetAllRequest(int userId);
        public Task<ServiceResponse<RequestDTO>> GetRequest(int requestId);
        public  Task<ServiceResponse<RequestDTO>> UpdateRequest(int requestId, RequestDTO requestUpdate);
    }
}
