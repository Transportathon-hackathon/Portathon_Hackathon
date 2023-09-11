using Microsoft.AspNetCore.Components.Forms;
using Portathon_Hackathon.Client.Services.Abstract;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared;
using System.Net.Http.Json;

namespace Portathon_Hackathon.Client.Services.Concrete
{
    public class FileManager : IFileManager
    {
        private readonly HttpClient _httpClient;    
        public FileManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<string> CreateImage(IBrowserFile file)
        {
            var result = await _httpClient.PostAsJsonAsync("https://localhost:7237/api/Company/UploadImage", file);
            return await result.Content.ReadFromJsonAsync<string>();
        }
    }
}
