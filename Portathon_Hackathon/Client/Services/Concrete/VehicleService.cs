using Portathon_Hackathon.Client.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;
using Portathon_Hackathon.Shared.Model;
using System.ComponentModel.Design;
using System.Net.Http.Json;

namespace Portathon_Hackathon.Client.Services.Concrete
{
    public class VehicleService : IVehicleService
    {
        private readonly HttpClient _httpClient;

        public VehicleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<VehicleDTO>> CreateVehicle(VehicleDTO dto, int companyId)
        {
            var result = await _httpClient.PostAsJsonAsync($"https://localhost:7237/api/Vehicle/{companyId}", dto);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<VehicleDTO>>();
        }

        public async Task<ServiceResponse<string>> DeleteVehicle(int vehicleId)
        {                                                 
            var result = await _httpClient.DeleteAsync($"https://localhost:7237/api/Vehicle/delete?vehicleId={vehicleId}");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }
    }
    
}
