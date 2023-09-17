using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portathon_Hackathon.Server.Context;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;
using Portathon_Hackathon.Shared.Model;
using System.Collections.Generic;
using System.Linq;

namespace Portathon_Hackathon.Server.Services.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public MessageService(ApplicationDbContext context,IMapper mapper,IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
            _context = context;
        }

        public async Task<ServiceResponse<List<MessageDTO>>> GetMessageSpecificUser(int receiverId)
        {
            ServiceResponse<List<MessageDTO>> _response = new ServiceResponse<List<MessageDTO>>();
            var userId = _userService.GetUserId();
            var userRole = await _context.Users.FindAsync(userId);
            var getAllMessages = await _context.Messages
                .Where(x => x.SenderId == userId && x.ReceiverId == receiverId || x.SenderId == receiverId && x.ReceiverId == userId)
                .ToListAsync();
            var messageDTO = _mapper.Map<List<MessageDTO>>(getAllMessages);
            _response.Data = messageDTO;
            return _response;
        }

        public async Task<ServiceResponse<List<SuitableMessageModel>>> GetMySuitableMessage()
        {
            ServiceResponse<List<SuitableMessageModel>> _response = new ServiceResponse<List<SuitableMessageModel>>();
            var user = _userService.GetUserId();
            var userRole = await _context.Users.FindAsync(user);

            if (user == null)
            {
                _response.Message = "No suitable criteria found";
                _response.Success = false;
            }
          
            var message = await _context.Requests
                .Include(x=>x.Vehicle)
                .ThenInclude(x=>x.Company)
                .ThenInclude(x=>x.User)
                .Where(x => x.UserId == user || x.Vehicle.Company.CompanyId == user).ToListAsync();
            List<SuitableMessageModel> _model = new List<SuitableMessageModel>();
            if (userRole.UserType == "Company")
            {
                foreach (var item in message)
                {
                    SuitableMessageModel _messageModel = new SuitableMessageModel();
                    _messageModel.ReceiverId = item.UserId;
                    _messageModel.AliasName = "Client";
                    _model.Add(_messageModel);

                }
            }
            else
            {

                foreach (var item in message)
                {
                    SuitableMessageModel _messageModel = new SuitableMessageModel();
                    _messageModel.ReceiverId = item.Vehicle.CompanyId;
                    _messageModel.AliasName = item.Vehicle.Company.CompanyName;
                    _model.Add(_messageModel);

                }
            }
          
            _response.Data = _model;
            _response.Success = true;
            return _response;
        }

        public async Task<ServiceResponse<List<Message>>> ListMyMessage(int messageId)
        {
            ServiceResponse<List<Message>> _response = new ServiceResponse<List<Message>>();
            var result = await _context.Messages
                .Include(x => x.Users)
                .Where(x => x.Id == messageId).ToListAsync();
            if(result != null)
            {
                _response.Data = result;
                return _response;
            }
            _response.Message = "You have no messages";
            return _response;


        }

        public async Task<ServiceResponse<List<MessageDTO>>> SendMessage(MessageDTO model)
        {
            ServiceResponse<List<MessageDTO>> _response = new ServiceResponse<List<MessageDTO>>();
            var objDTO = _mapper.Map<Message>(model);
            objDTO.TimeSpan = DateTime.Now;
            _context.Messages.Add(objDTO);
            if (await _context.SaveChangesAsync() > 0)
            {
                var userId =  _userService.GetUserId();
                var getAllMessages = await _context.Messages
                    .Where(x => x.SenderId == userId && x.ReceiverId == model.ReceiverId || x.SenderId == model.ReceiverId && x.ReceiverId == userId)
                    .ToListAsync();
                var messageDTO = _mapper.Map<List<MessageDTO>>(getAllMessages);
                _response.Data = messageDTO;
                _response.Success = true;
                return _response;
            }
            _response.Message = "You dont have any messages";
            return _response;
        }
    }
}
