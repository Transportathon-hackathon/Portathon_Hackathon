using Portathon_Hackathon.Client.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;
using System.Net.Http.Json;

namespace Portathon_Hackathon.Client.Services.Concrete
{
    public class ReservationManager : IReservationManager
    {
        private HttpClient _httpClient;
        public ReservationManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<ReservationReturnDTO>> GetReservationById(int reservationId)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<ReservationReturnDTO>>($"https://localhost:7237/api/reservation?reservationId={reservationId}");
            return response;
        }

        public async Task<ServiceResponse<List<ReservationReturnDTO>>> GetReservationByUser()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<ReservationReturnDTO>>>("https://localhost:7237/api/reservation/GetReservationByUserId");
           
            return response;
        }

        public async Task<ServiceResponse<Reservation>> ReservationFeedBack(int requestId,ReservationDTO reservation)
        {
            var result = await _httpClient.PostAsJsonAsync($"https://localhost:7237/api/reservation", reservation);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<Reservation>>();
           
        }

    }
}
