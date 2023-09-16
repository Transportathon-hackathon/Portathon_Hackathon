using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Services.Abstract
{
    public interface ICrewMemberService
    {
        Task<ServiceResponse<List<CrewMemberDTO>>> GetAllCrewMemberByVehicleId(int vehicleId);
        Task<ServiceResponse<string>> DeleteCrewMemberById(int crewMemberId);
        Task<ServiceResponse<CrewMember>> CreateCrewMember(CrewMemberDTO request, int vehicleId);
    }
}
