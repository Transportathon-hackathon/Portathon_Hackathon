using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            var reservation = _mapper.Map<Reservation>(reservationDTO);

            if (reservation.ReservationCase.ToString() == "Rejected")
            {
               
                await _requestService.DeleteRequest(reservation.RequestId); // Request Deleted because it's recejted
                await _context.SaveChangesAsync();
                return new ServiceResponse<Reservation>
                {
                    Data = null,
                    Message = "Reservation İs Rejected",
                    Success = true
                };
            }
            else if (reservation.ReservationCase.ToString() == "Accepted")
            {
                await _context.Reservations.AddAsync(reservation);
                await _context.SaveChangesAsync();

                //This method has written because I wanted to return request too with reservation to see if there is ant request detail which may be
                //important to company and the user like any request condition detail
                var reservatioData =await _context.Reservations.Where(opt => opt.ReservationId == reservation.ReservationId)
                    .Include(opt =>opt.Request).FirstOrDefaultAsync();


                return new ServiceResponse<Reservation>
                {
                    Data = reservatioData, // we can return reservation too it will work correctly
                    Message = "Reservation Added",
                    Success = true
                };
            }

            return new ServiceResponse<Reservation>
            {
                Data = null,
                Message = "The reservation Case didn't recognize",
                Success = true
            };

        }


        public async Task<ServiceResponse<List<Reservation>>> GetAllReservations()
        {
            var reservations =await _context.Reservations.ToListAsync();
            return new ServiceResponse<List<Reservation>>
            {
                Data = reservations,
                Success = true,
                Message = "Reservations Listed"
            };
        }

        public async Task<ServiceResponse<ReservationReturnDTO>> GetReservation(int reservationId)
        {
            var reservation = await _context.Reservations
            .Where(opt => opt.ReservationId == reservationId)
            .Include(opt => opt.Request)
            .ThenInclude(opt => opt.Vehicle)
            .Include(opt => opt.Request)
            .ThenInclude(opt => opt.User)  
            .FirstOrDefaultAsync();


            if (reservation == null)
            {
                return new ServiceResponse<ReservationReturnDTO>
                {
                    Data = null,
                    Success = false,
                    Message = "There is no reservation with this id"
                };
            }
            var objDTO = _mapper.Map<ReservationReturnDTO>(reservation);
            return new ServiceResponse<ReservationReturnDTO>
            {
                Data = objDTO,
                Success = true,
                Message = "Reservation is getted"
            };
        }

        public async Task<ServiceResponse<List<ReservationReturnDTO>>> GetReservationByUserId(int userId)
        {
            var reservation = await _context.Reservations
              .Where(opt => opt.Request.UserId == userId)
              .Include(opt => opt.Request)
              .ThenInclude(opt => opt.Vehicle)
              .Include(opt => opt.Request)
              .ThenInclude(opt => opt.User)
              .ToListAsync();


            var reservationDto = _mapper.Map<List<ReservationReturnDTO>>(reservation);
            
            if(reservationDto == null)
            {
                return new ServiceResponse<List<ReservationReturnDTO>>
                {
                    Data = null,
                    Message = "Ypu have no reservagtion",
                    Success = false,

                };
            }

            return new ServiceResponse<List<ReservationReturnDTO>>
            {
                Data = reservationDto,
                Message = "The user's Reservations getted",
                Success = true,

            };

        }
    }
}
