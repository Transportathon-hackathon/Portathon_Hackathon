using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;

namespace Portathon_Hackathon.Server.Services.Abstract
{
    public interface IEvaluationService
    {
        Task<ServiceResponse<EvaluationDTO>> EvaluationCreate(int reservationId,EvaluationDTO model);
    }
}
