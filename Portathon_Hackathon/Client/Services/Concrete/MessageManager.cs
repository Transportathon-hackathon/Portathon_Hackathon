using Portathon_Hackathon.Client.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Model;
using System.Net.Http;
using System.Net.Http.Json;

namespace Portathon_Hackathon.Client.Services.Concrete
{
    public class MessageManager : IMessageManager
    {
        private readonly HttpClient _httpClient;
        public MessageManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MessageDTO>> GetMessageSpecificUser(int receiverId)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<MessageDTO>>>($"https://localhost:7237/api/Message/userMessages?receiverId={receiverId}");
            return result.Data;
        }

        public async Task<List<SuitableMessageModel>> GetSuitableMessageAsync()
        {
            var result = await _httpClient.GetFromJsonAsync< ServiceResponse<List<SuitableMessageModel>>>("https://localhost:7237/api/Message");
            return  result.Data;
        }

        public async Task<ServiceResponse<List<MessageDTO>>> SendMessage(MessageDTO model)
        {
            //https://localhost:7237/api/Message
            var result = await _httpClient.PostAsJsonAsync("https://localhost:7237/api/Message", model);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<List<MessageDTO>>>();
        }
    }
}
