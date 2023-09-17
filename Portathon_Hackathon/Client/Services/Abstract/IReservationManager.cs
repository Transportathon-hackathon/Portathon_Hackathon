using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Client.Services.Abstract
{
    public interface IReservationManager
    {
        Task<ServiceResponse<List<ReservationReturnDTO>>> GetReservationByUser();
        Task<ServiceResponse<ReservationReturnDTO>> GetReservationById(int reservationId);

        Task<ServiceResponse<Reservation>> ReservationFeedBack(int requestId, ReservationDTO reservation);
    }
}
