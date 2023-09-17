using Microsoft.AspNetCore.Components.Authorization;
using Portathon_Hackathon.Client.Services.Abstract;
using Portathon_Hackathon.Shared.Model;
using Portathon_Hackathon.Shared;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using Portathon_Hackathon.Client.TokenProcess;

namespace Portathon_Hackathon.Client.Services.Concrete
{
    public class AuthManager : IAuthManager
    {
        //https://localhost:7237/api/Auth/register
        //https://localhost:7237/api/Auth/login

        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _stateProvider;
        private readonly ILocalStorageService _localStorageService;

        public AuthManager(HttpClient httpClient, AuthenticationStateProvider stateProvider, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _stateProvider = stateProvider;
            _localStorageService = localStorageService;
        }

        public async Task<bool> IsUserAuthenticated()
        {
            return (await _stateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }


     

        public async Task<ServiceResponse<string>> Login(UserLogin user)
        {
            var result = await _httpClient.PostAsJsonAsync("https://localhost:7237/api/Auth/login", user);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }


        public async Task<ServiceResponse<int>> CreateUser(UserRegister registerModel) {
            var result = await _httpClient.PostAsJsonAsync("https://localhost:7237/api/Auth", registerModel);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        
        }



        //public async Task<ServiceResponse<int>> Register(UserRegister request)
        //{
        //    var deneme = _httpClient.BaseAddress;
        //    var result = await _httpClient.PostAsJsonAsync("https://localhost:7237/api/Auth/register", request);
        //    return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();

        //}


        public async Task Logout()
        {
            await _localStorageService.RemoveItemAsync("authToken");

            //((CustomAuthStateProvider)_stateProvider).NotifyUserLogout();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

    }
}
