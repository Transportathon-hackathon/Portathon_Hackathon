using Microsoft.AspNetCore.Mvc;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Shared.DTO;

namespace Portathon_Hackathon.Server.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    public class ReservationController :ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
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
        public async Task<ActionResult> GetReservationByReservationId(int reservationId)
        {
            var response = await _reservationService.GetReservation(reservationId);

            return Ok(response);
        }

        [HttpGet("getreservationbyuserid")]
        public async Task<ActionResult> GetReservationByUserId(int userId)
        {
            var response = await _reservationService.GetReservationByUserId(userId);

            return Ok(response);
        }

    }
}
