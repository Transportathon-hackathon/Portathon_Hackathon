using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;

namespace Portathon_Hackathon.Client.Services.Abstract
{
    public interface IEValuateManager
    {
        Task<ServiceResponse<EvaluationDTO>> CreateEValuateAsync(int reservationId,EvaluationDTO model);
    }
}
