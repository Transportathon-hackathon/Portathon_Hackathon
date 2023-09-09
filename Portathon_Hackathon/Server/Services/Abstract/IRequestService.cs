using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Services.Abstract
{
    public interface IRequestService
    {
        Task<ServiceResponse<Request>> CreateRequest(Request request);
    }
}
