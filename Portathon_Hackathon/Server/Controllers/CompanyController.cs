using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using System.Security.Claims;

namespace Portathon_Hackathon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }



        [HttpPost]
        [Authorize(Roles ="Company")]
        public async Task<ActionResult> CreateCompany(CompanyDTO obj)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            obj.UserId = userId;
            var result = await _companyService.CreateCompany(obj);
            if(result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcompany")]
        public async Task<ActionResult> GetCompany(int companyId)
        {
            var result = await _companyService.GetCompanyFeatures(companyId);
          return Ok(result);
        }

        [Authorize(Roles ="Company")]
        [HttpGet("getcompanyid")]
        public async Task<ActionResult> GetCompanyIdByUserId()
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var result = await _companyService.GetCompanyIdByUserId(userId);
            return Ok(result);
        }


        [HttpGet]
        public async Task<ActionResult> GetAllCompanies()
        {
            var result = await _companyService.GetAllCompanies();   
            if(result.Success == true)
            {
                return Ok(result);  
            }
            return BadRequest(result);  
        }
        [HttpGet("checkcompany")]
        public async Task<ActionResult> CompanyCreatedOrNot(int userId)
        {
            var result =await _companyService.CompanyCreatedOrNot(userId);
            if(result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
