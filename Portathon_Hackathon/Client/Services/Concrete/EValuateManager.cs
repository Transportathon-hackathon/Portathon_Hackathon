using Portathon_Hackathon.Client.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;

namespace Portathon_Hackathon.Client.Services.Concrete
{
    public class EValuateManager : IEValuateManager
    {
        private readonly HttpClient _httpClient;
        public EValuateManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //https://localhost:7237/api/EValuation/2
        public async Task<ServiceResponse<EvaluationDTO>> CreateEValuateAsync(int reservationId, EvaluationDTO model)
        {
            var result = await _httpClient.PostAsJsonAsync($"https://localhost:7237/api/EValuation/{reservationId}", model);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<EvaluationDTO>>();
        }
    }
}
