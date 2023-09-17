using Portathon_Hackathon.Client.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;

namespace Portathon_Hackathon.Client.Services.Concrete
{
    public class ReqeustManager : IRequestManager
    {
        private HttpClient _httpClient;

        public ReqeustManager(HttpClient http)
        {
            _httpClient =  http;
        }
        public async Task<ServiceResponse<string>> DeleteRequest(int requestId)
        {
            var result = await _httpClient.DeleteAsync($"https://localhost:7237/api/Request?requestId={requestId}");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }
        public async Task<ServiceResponse<List<RequestDTO>>> GetAllRequestByUserId(int userId)
        {                 
            var result = await _httpClient.GetAsync($"https://localhost:7237/getrequestsbyuserid?userId={userId}");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<List<RequestDTO>>>();
        }

        public async Task<ServiceResponse<List<Request>>> GetAllRequestForCompany(int companyId)
        {

            var result = await _httpClient.GetAsync($"https://localhost:7237/api/request/GetCompanyRequest?companyId={companyId}");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<List<Request>>>();
        }

        public async Task<ServiceResponse<RequestDTO>> MakeRequest(RequestDTO dto)
        {
            var result = await _httpClient.PostAsJsonAsync("https://localhost:7237/api/Request", dto);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<RequestDTO>>();
        }

        public Task<ServiceResponse<RequestDTO>> UpdateYourRequest(int updateId, RequestDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
