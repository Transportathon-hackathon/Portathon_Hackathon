using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ServiceResponse<CrewMember>> CreateCrewMember(CrewMemberDTO request, int vehicleId)
        {
            var objDTO = _mapper.Map<CrewMember>(request);
            ServiceResponse<CrewMember> response = new ServiceResponse<CrewMember>();
            objDTO.VehicleId = vehicleId;
            if (objDTO != null)
            {
                _context.CrewMembers.Add(objDTO);
                if (await _context.SaveChangesAsync() > 0)
                {
                    response.Success = true;
                    response.Message = "Crew Member Created";
                    response.Data = objDTO;
                    return response;
                }
            }
            response.Success = false;
            response.Message = "Crew Member is not Created";
            return response;
        }

        public async Task<ServiceResponse<string>> DeleteCrewMemberById(int crewMemberId)
        {
            var crew = await _context.CrewMembers.Where(opt => opt.Id == crewMemberId).FirstOrDefaultAsync();
        
            if(crew != null)
            {
                _context.CrewMembers.Remove(crew);
                await _context.SaveChangesAsync();
                return new ServiceResponse<string>
                {
                    Success = true,
                    Message = "Crew Deleted",
                    Data = null
                };
            }
            return new ServiceResponse<string>
            {
                Data = null,
                Success = false,
                Message = "An error occured while deting the crew member"
            };
                
                
        }

        public async Task<ServiceResponse<List<CrewMemberDTO>>> GetAllCrewMemberByVehicleId(int vehicleId)
        {
            var crewList =await _context.CrewMembers.Where(opt => opt.VehicleId == vehicleId).ToListAsync();
     
            var crewDTO = _mapper.Map<List<CrewMemberDTO>>(crewList);

            if(crewDTO == null)
            {
                return new ServiceResponse<List<CrewMemberDTO>>
                {
                    Data = null,
                    Message = "CrewMembers could not found",
                    Success = false
                };
            }
            return new ServiceResponse<List<CrewMemberDTO>>
            {
                Data = crewDTO,
                Message = "CrewMembers getted",
                Success = true
            };

        }
    }
}
