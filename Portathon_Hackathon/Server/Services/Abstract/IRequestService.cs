using Microsoft.Exchange.WebServices.Data;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Services.Abstract
{
    public interface IRequestService
    {
        Task<ServiceResponse> CreateRequest(Request request);
    }
}
