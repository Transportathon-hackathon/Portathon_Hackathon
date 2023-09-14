using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Services.Abstract
{
    public interface IVehicleService
    {
        Task<ServiceResponse<VehicleDTO>> CreateVehicle(VehicleDTO request,int companyId);
        Task<ServiceResponse<List<VehicleDTO>>> GetAllVehiclesByCompanyId(int companyId);
        Task<ServiceResponse<VehicleDTO>> GetVehicleById(int vehicleId);
        Task<ServiceResponse<VehicleDTO>> UpdateVehicle(int vehicleId, VehicleDTO dto);
        Task<ServiceResponse<string>> DeleteVehicle(int vehicleId);
        Task<ServiceResponse<List<VehicleReturnDTO>>> GetAllVehicles();
    }
}
