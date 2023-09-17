using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;
using Portathon_Hackathon.Shared.Model;

namespace Portathon_Hackathon.Server.Services.Abstract
{
    public interface IMessageService
    {
        Task<ServiceResponse<List<Message>>> ListMyMessage(int messageId);
        Task<ServiceResponse<List<SuitableMessageModel>>> GetMySuitableMessage();

        Task<ServiceResponse<List<MessageDTO>>> SendMessage(MessageDTO model);
        Task<ServiceResponse<List<MessageDTO>>> GetMessageSpecificUser(int receiverId);
    }
}
