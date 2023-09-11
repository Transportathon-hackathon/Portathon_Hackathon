using Portathon_Hackathon.Client.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;
using System.Net.Http.Json;

namespace Portathon_Hackathon.Client.Services.Concrete
{
    public class CompanyManager : ICompanyManager
    {
        private readonly HttpClient _httpClient;
        public CompanyManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        public async Task<ServiceResponse<CompanyDTO>> CreateCompany(CompanyDTO model)
        {
            var result = await _httpClient.PostAsJsonAsync("https://localhost:7237/api/Company", model);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<CompanyDTO>>();

        }

        public async Task<ServiceResponse<List<CompanyDTO>>> GetAllCompany()
        {
            var result = await _httpClient.GetAsync("https://localhost:7237/api/Company");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<List<CompanyDTO>>>();
        }
    }
}
