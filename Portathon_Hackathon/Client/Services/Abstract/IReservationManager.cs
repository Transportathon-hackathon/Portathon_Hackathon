using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;

namespace Portathon_Hackathon.Client.Services.Abstract
{
    public interface IReservationManager
    {
        Task<ServiceResponse<List<ReservationReturnDTO>>> GetReservationByUser();
        Task<ServiceResponse<ReservationReturnDTO>> GetReservationById(int reservationId);
    }
}
