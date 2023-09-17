using AutoMapper;
using Portathon_Hackathon.Server.Context;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Services.Concrete
{
    public class EValuationService : IEvaluationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public EValuationService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<EvaluationDTO>> EvaluationCreate(int reservationId,EvaluationDTO model)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);
            ServiceResponse<EvaluationDTO> _response = new ServiceResponse<EvaluationDTO>();
            if (reservation != null)
            {
                reservation.IsReservationFinish = true; 
                await _context.SaveChangesAsync();//reservation kapandı anlamına gelmesi gerekmektedir.
            }
            var objDTO = _mapper.Map<Evaluation>(model);
            _context.Evaluations.Add(objDTO);
        
            if(await _context.SaveChangesAsync() > 0)
            {
                _response.Success = true;
                _response.Message = "Your evaluate is sended";
                _response.Data = model;
                return _response;
            }
            _response.Success = false;
            return _response;
        
        }
    }
}
