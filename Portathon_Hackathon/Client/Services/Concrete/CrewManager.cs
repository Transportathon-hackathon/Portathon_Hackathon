using Portathon_Hackathon.Client.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;
using System.Net.Http.Json;

namespace Portathon_Hackathon.Client.Services.Concrete
{
    public class CrewManager : ICrewManager
    {
        private readonly HttpClient _httpClient;

        public CrewManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<CrewMember>> AddCrewMemberToVehicle(int vehicleId, CrewMemberDTO dto)
        {
            var result = await _httpClient.PostAsJsonAsync($"https://localhost:7237/api/CrewMember/{vehicleId}", dto);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<CrewMember>>();
        }

        public async Task<ServiceResponse<List<CrewMemberDTO>>> GetAllCrewMembersByVehicleId(int vehicleId)
        {
            var result = await _httpClient.GetAsync($"https://localhost:7237/api/CrewMember/getallcrewsbyvehicleId?vehicleId={vehicleId}");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<List<CrewMemberDTO>>>();



        }
        public async Task<ServiceResponse<string>> DeleteCrewMemberById(int id)
        {
            var result = await _httpClient.DeleteAsync($"https://localhost:7237/api/CrewMember/delete?id={id}");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();

        }
    }
}
