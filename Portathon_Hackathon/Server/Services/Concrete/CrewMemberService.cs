using AutoMapper;
using Portathon_Hackathon.Server.Context;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Services.Concrete
{
    public class CrewMemberService : ICrewMemberService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CrewMemberService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CrewMemberDTO>> CreateCrewMember(CrewMemberDTO request, int vehicleId)
        {
            var objDTO = _mapper.Map<CrewMember>(request);
            ServiceResponse<CrewMemberDTO> response = new ServiceResponse<CrewMemberDTO>();
            objDTO.VehicleId = vehicleId;
            if (objDTO != null)
            {
                _context.CrewMembers.Add(objDTO);
                if (await _context.SaveChangesAsync() > 0)
                {
                    response.Success = true;
                    response.Message = "Crew Member Created";
                    response.Data = request;
                    return response;
                }
            }
            response.Success = false;
            response.Message = "Crew Member is not Created";
            return response;
        }
    }
}
