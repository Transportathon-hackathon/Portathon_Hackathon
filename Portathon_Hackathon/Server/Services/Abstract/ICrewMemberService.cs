using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared;

namespace Portathon_Hackathon.Server.Services.Abstract
{
    public interface ICrewMemberService
    {
        Task<ServiceResponse<CrewMemberDTO>> CreateCrewMember(CrewMemberDTO request, int vehicleId);
    }
}
