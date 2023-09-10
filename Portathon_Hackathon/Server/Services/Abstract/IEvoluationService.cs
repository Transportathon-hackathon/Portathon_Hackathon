using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Services.Abstract
{
    public interface IEvoluationService
    {
        Task<ServiceResponse<Evaluation>> CreateEvaluation(EvaluationDTO evaluation);
    }
}
