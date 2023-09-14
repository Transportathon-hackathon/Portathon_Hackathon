
using BlazorInputFile;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using System.Net.Http;

namespace Portathon_Hackathon.Client.Services.Helper
{
    public class FileUploadService : IFileUploadService
    {
        private readonly HttpClient _httpClient;
        public FileUploadService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> FileUploadAsync(IFileListEntry file, string folderName,int fileContent)
        {
            try
            {
                var ms = new MemoryStream();
                await file.Data.CopyToAsync(ms);
                var content = new MultipartFormDataContent
                {
                    {
                    new ByteArrayContent(ms.GetBuffer()),folderName,file.Name

                    }
                };
                var response = await _httpClient.PostAsync($"https://localhost:7237/api/UploadFile/FileUploadAsync/{fileContent}", content);
                var contentresult = await response.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<bool>(contentresult);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
