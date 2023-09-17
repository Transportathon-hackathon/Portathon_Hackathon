using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portathon_Hackathon.Server.Context;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;
using Portathon_Hackathon.Shared.Model;

namespace Portathon_Hackathon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _context;
        public MessageController(IMessageService messageService
                                , IUserService userService, 
                                    ApplicationDbContext context)
        {
            _messageService = messageService;
            _userService = userService;
            _context = context;
        }



        [HttpPost]
        public async Task<ActionResult> SendMessageSystem(MessageDTO model)
        {
            var user = HttpContext.User.Identity.Name;
            if (user != null)
            {
                var userDetail = await _context.Users.FirstOrDefaultAsync(x => x.Email == user);
                model.SenderId = userDetail.Id;

            }
            var result = await _messageService.SendMessage(model);
            return Ok(result);
        }


        [HttpGet("userMessages")]
        public async Task<ActionResult> GetSpecificUserMessages(int receiverId)
        {
            var response = await _messageService.GetMessageSpecificUser(receiverId);
            return Ok(response);
        }


        [HttpGet]
        public async Task<ActionResult> GetMySuitableCompany()
        {
            var response = await _messageService.GetMySuitableMessage();
            return Ok(response);
        }
    }
}
