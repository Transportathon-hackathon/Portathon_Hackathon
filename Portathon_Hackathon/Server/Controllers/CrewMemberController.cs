using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Server.Services.Concrete;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;

namespace Portathon_Hackathon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrewMemberController : ControllerBase
    {

        private readonly ICrewMemberService _crewMemberService;
        public CrewMemberController(ICrewMemberService crewMemberService)
        {
            _crewMemberService = crewMemberService;
        }


        [HttpPost("{vehicleId}")]
        public async Task<ActionResult> CreateCrewMember(CrewMemberDTO obj, [FromRoute] int vehicleId)
        {
            var result = await _crewMemberService.CreateCrewMember(obj, vehicleId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallcrewsbyvehicleId")]
        public async Task<ActionResult> GetAllCrewMemberByVehicleId(int vehicleId)
        {
            var result = await _crewMemberService.GetAllCrewMemberByVehicleId(vehicleId);

            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteCrewMemberById(int id)
        {
            var result = await _crewMemberService.DeleteCrewMemberById(id);

            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
