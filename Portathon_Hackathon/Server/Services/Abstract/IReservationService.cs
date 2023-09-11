using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Services.Abstract
{
    public interface IReservationService
    {
        Task<ServiceResponse<Reservation>> CreateReservation(ReservationDTO reservationDTO);
        Task<ServiceResponse<ReservationReturnDTO>> GetReservation(int reservationId);
        Task<ServiceResponse<List<ReservationReturnDTO>>> GetReservationByUserId(int reservationId);
        Task<ServiceResponse<List<Reservation>>> GetAllReservations();
    }
}
