using Microsoft.AspNetCore.Components.Authorization;
using Portathon_Hackathon.Client.Services.Abstract;
using Portathon_Hackathon.Shared.Model;
using Portathon_Hackathon.Shared;
using System.Net.Http.Json;

namespace Portathon_Hackathon.Client.Services.Concrete
{
    public class AuthManager : IAuthManager
    {
        //https://localhost:7237/api/Auth/register
        //https://localhost:7237/api/Auth/login

        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _stateProvider;

        public AuthManager(HttpClient httpClient, AuthenticationStateProvider stateProvider)
        {
            _httpClient = httpClient;
            _stateProvider = stateProvider;
        }

        public async Task<bool> IsUserAuthenticated()
        {
            return (await _stateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

        public async Task<ServiceResponse<string>> Login(UserLogin user)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Auth/login", user);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<int>> Register(UserRegister request)
        {
            var deneme = _httpClient.BaseAddress;
            var result = await _httpClient.PostAsJsonAsync("api/Auth/register", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();

        }
    }
}
