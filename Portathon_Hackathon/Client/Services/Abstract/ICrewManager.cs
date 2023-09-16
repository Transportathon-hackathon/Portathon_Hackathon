using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Client.Services.Abstract
{
    public interface ICrewManager
    {
        Task<ServiceResponse<List<CrewMemberDTO>>> GetAllCrewMembersByVehicleId(int vehicleId);
        Task<ServiceResponse<CrewMember>> AddCrewMemberToVehicle(int vehicleId, CrewMemberDTO dto);
        Task<ServiceResponse<string>> DeleteCrewMemberById(int id);
    }
}
