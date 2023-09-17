using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Shared.DTO;

namespace Portathon_Hackathon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EValuationController : ControllerBase
    {
        private readonly IEvaluationService _valuationService;
        public EValuationController(IEvaluationService valuationService)
        {
            _valuationService = valuationService;
        }


        [HttpPost("{reservationId}")]
        public async Task<ActionResult> SendEvaluate([FromRoute]int reservationId,EvaluationDTO model)
        {
            var response = await _valuationService.EvaluationCreate(reservationId, model);
            return Ok(response);    
        }
    }
}
