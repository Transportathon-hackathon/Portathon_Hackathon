using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Server.Services.Concrete;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using System.Security.Claims;

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
                return Ok(result);
            }
            return BadRequest(result);
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
        [HttpPut]
        public async Task<ActionResult> UpdateVehicle(int vehicleId, VehicleDTO dto)
        {
           
            var response = await  _vehicleService.UpdateVehicle(vehicleId,dto);

            return Ok(response);
        }

        [HttpDelete("/delete")]
        public async Task<ActionResult> DeleteVehicle(int vehicleId)
        {
            var response =await _vehicleService.DeleteVehicle(vehicleId);
            return Ok(response);
        }


    }
}
