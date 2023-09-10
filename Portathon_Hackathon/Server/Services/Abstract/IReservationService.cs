using Microsoft.Exchange.WebServices.Data;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Services.Abstract
{
    public interface IReservationService
    {
        Task<ServiceResponse<Reservation>> CreateReservation(ReservationDTO reservationDTO);
        Task<ServiceResponse<Reservation>> GetReservation(ReservationDTO reservationDTO);
        Task<ServiceResponse<Reservation>> GetAllReservations(ReservationDTO reservationDTO);
    }
}
