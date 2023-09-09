using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Services.Concrete
{
    public class RequestService : IRequestService
    {
        public Task<ServiceResponse<Request>> CreateRequest(Request request)
        {
            throw new NotImplementedException();
        }
    }
}
