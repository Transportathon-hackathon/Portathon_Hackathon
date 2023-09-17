using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Model;

namespace Portathon_Hackathon.Client.Services.Abstract
{
    public interface IMessageManager
    {
        Task<ServiceResponse<List<MessageDTO>>> SendMessage(MessageDTO model);
        Task<List<SuitableMessageModel>> GetSuitableMessageAsync();
        Task<List<MessageDTO>> GetMessageSpecificUser(int reveiverId);
    }
}
