using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Services.Abstract
{
    public interface IVehicleService
    {
        Task<ServiceResponse<VehicleDTO>> CreateVehicle(VehicleDTO request,int companyId);
    }
}
