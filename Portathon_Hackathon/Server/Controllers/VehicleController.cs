using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;

namespace Portathon_Hackathon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }


        [HttpPost("{companyId}")]
        public async Task<ActionResult> CreateVehicle(VehicleDTO obj,[FromRoute]int companyId)
        {
            var result = await _vehicleService.CreateVehicle(obj,companyId);
            if (result.Success == true)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{companyId}")]
        public async Task<ActionResult<ServiceResponse<VehicleDTO>>> GetAllVehicles([FromRoute] int companyId)
        {
            var result = await _vehicleService.GetAllVehicles(companyId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<VehicleDTO>>> GetWehiclesById(int vehicleId)
        {
            var result = await _vehicleService.GetVehicleById(vehicleId);    
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



    }
}
