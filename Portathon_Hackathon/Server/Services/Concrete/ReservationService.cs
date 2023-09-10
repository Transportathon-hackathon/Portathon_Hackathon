using AutoMapper;
using Portathon_Hackathon.Server.Context;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Services.Concrete
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IRequestService _requestService;

        public ReservationService(ApplicationDbContext context,IMapper mapper,IRequestService requestService)
        {
            _context = context;  
            _mapper = mapper;
            _requestService = requestService;
        }
       public async Task<ServiceResponse<Reservation>> CreateReservation(ReservationDTO reservationDTO)
{
    try
    {
        var reservation = _mapper.Map<Reservation>(reservationDTO);

        if (reservation.ReservationCase.ToString() == "Rejected")
        {
            _context.Reservations.Remove(reservation);
        }
        else if (reservation.ReservationCase.ToString() == "Accepted")
        {
            await _context.Reservations.AddAsync(reservation);
        }
        else
        {
            return new ServiceResponse<Reservation>
            {
                Data = null,
                Message = "The reservation case is not recognized",
                Success = false
            };
        }

        await _context.SaveChangesAsync();
        await _requestService.DeleteRequest(reservation.RequestId);

        return new ServiceResponse<Reservation>
        {
            Data = reservation,
            Message = "Reservation successfully processed",
            Success = true
        };
    }
    catch (Exception ex)
    {
        // Handle exceptions, log them, and return an error response.
        return new ServiceResponse<Reservation>
        {
            Data = null,
            Message = "An error occurred while processing the reservation",
            Success = false
        };
    }
}


        public Task<ServiceResponse<Reservation>> GetAllReservations(ReservationDTO reservationDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Reservation>> GetReservation(ReservationDTO reservationDTO)
        {
            throw new NotImplementedException();
        }
    }
}
