using Microsoft.AspNetCore.Mvc;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Shared.DTO;

namespace Portathon_Hackathon.Server.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    public class ReservarionController :ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservarionController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<ActionResult>  ReservationFeedBack(ReservationDTO reservation)
        {
             var response = await _reservationService.CreateReservation(reservation);

            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult> ReservationFeedBack(int reservationId)
        {
            var response = await _reservationService.GetReservation(reservationId);

            return Ok(response);
        }
    }
}
