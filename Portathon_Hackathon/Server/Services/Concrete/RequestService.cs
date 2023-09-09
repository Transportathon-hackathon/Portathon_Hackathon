using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using Portathon_Hackathon.Server.Context;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Services.Concrete
{
    public class RequestService : IRequestService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RequestService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       

        public async Task<ServiceResponse<RequestDTO>> CreateRequest(int userId,RequestDTO requestDto)
        {
            var request = _mapper.Map<Request>(requestDto);
            request.UserId = userId;
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
            return new ServiceResponse<RequestDTO>
            {
                Data = requestDto,
                Message = "Request Has Sended",
                Success = true
            };
        }

        public async Task<ServiceResponse<string>> DeleteRequest(int requestId)
        {
            var request =await _context.Requests.Where(opt => opt.RequestId == requestId).FirstOrDefaultAsync();
            if(request == null)
            {
                throw new ArgumentNullException(nameof(request));

            }
            
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return new ServiceResponse<string> 
            {
                Data= "Request Deleted",
                Message = "Deleted the request",
                Success = true
            };
        }

        public async Task<ServiceResponse<List<RequestDTO>>> GetAllRequest(int userId)
        {

           var requests =await _context.Requests.Where(opt => opt.UserId == userId).ToListAsync();
           var data = _mapper.Map<List<RequestDTO>>(requests);
           return new ServiceResponse<List<RequestDTO>>
            {
                Data = data,
                Message = "All Requests Has Listed",
                Success = true
            };

        }

        public  async Task<ServiceResponse<RequestDTO>> GetRequest(int requestId)
        {
            var request =await _context.Requests.Where(opt => opt.RequestId == requestId).FirstOrDefaultAsync();
            var data = _mapper.Map<RequestDTO>(request);

            if(data != null) 
            {
                return new ServiceResponse<RequestDTO>
                {
                    Data = data,
                    Message = "The request is getted ",
                    Success = true
                };
            }

            return new ServiceResponse<RequestDTO>
            {
                Data = null,
                Message = "There is no request ",
                Success = true
            };

        }
    }
}
