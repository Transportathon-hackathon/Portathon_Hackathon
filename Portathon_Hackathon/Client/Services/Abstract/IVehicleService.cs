using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;

namespace Portathon_Hackathon.Client.Services.Abstract
{
    public interface IVehicleService
    {
        Task<ServiceResponse<VehicleDTO>> CreateVehicle(VehicleDTO dto, int companyId);
    }
}
