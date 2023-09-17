using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using System.Security.Claims;

namespace Portathon_Hackathon.Server.Controllers
{
    [Route("api/request")]
    [ApiController]
    public class RequestController: ControllerBase
    {
        private readonly IRequestService _requestService;
        
        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateRequest(RequestDTO requestDTO)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _requestService.CreateRequest(Convert.ToInt32(userId),requestDTO);
           return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult> GetRequst(int requstId)
        {
            var response = await _requestService.GetRequest(requstId);
            return Ok(response);
        }
        [HttpGet("/getrequestsbyuserid")]
        public async Task<ActionResult> GetAllRequestsByUserId(int userId)
        {
            
            var response = await _requestService.GetAllRequest(userId);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteRequest(int requestId)
        {
            var response = await _requestService.DeleteRequest(requestId);
            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateRequest(int requestId,RequestDTO requestDTO)
        {
            var response = await _requestService.UpdateRequest(requestId, requestDTO);
            return Ok(response);
        }
        [HttpGet("GetCompanyRequest")]
        public async Task<ActionResult> GetAllRequest(int companyId)
        {
            var result = await _requestService.RequestForCompanyList(companyId);
            return Ok(result);  
        }
    }
}
