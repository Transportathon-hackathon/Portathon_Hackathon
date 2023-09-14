using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;

namespace Portathon_Hackathon.Client.Services.Abstract
{
    public interface IVehicleService
    {
        Task<ServiceResponse<VehicleDTO>> CreateVehicle(VehicleDTO dto, int companyId);
        Task<ServiceResponse<string>> DeleteVehicle(int vehicleId);
        Task<ServiceResponse<List<VehicleReturnDTO>>> GetAllVehicles();
        Task<ServiceResponse<VehicleDTO>> UpdateVehicles(int vehicleId,VehicleDTO dto);
        Task<ServiceResponse<VehicleDTO>> GetVehicleById(int vehicleId);
    }
}
