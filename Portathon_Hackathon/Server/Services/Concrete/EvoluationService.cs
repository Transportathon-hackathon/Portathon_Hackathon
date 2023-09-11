using AutoMapper;
using Portathon_Hackathon.Server.Context;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Services.Concrete
{
    public class EvoluationService : IEvoluationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EvoluationService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<Evaluation>> CreateEvaluation(EvaluationDTO evaluationDto)
        {
            var evaluation = _mapper.Map<Evaluation>(evaluationDto);
            await _context.Evaluations.AddAsync(evaluation);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Evaluation>
            { 
                Data = evaluation, Success = true, Message = "You have Evaluated The Company Successfully"
            };

        }
    }
}
