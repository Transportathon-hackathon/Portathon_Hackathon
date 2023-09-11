using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Shared.DTO;

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
            var result = await _companyService.CreateCompany(obj);
            if(result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{companyId}")]
        public async Task<ActionResult> GetCompany([FromRoute]int companyId)
        {
            var result = await _companyService.GetCompanyFeatures(companyId);
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


    }
}
