using Microsoft.Exchange.WebServices.Data;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Services.Concrete
{
    public class RequestService : IRequestService
    {
        public Task<ServiceResponse> CreateRequest(Request request)
        {
            throw new NotImplementedException();
        }
    }
}
