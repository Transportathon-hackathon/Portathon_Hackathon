using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public bool UserAlreadyRequested(int VehicleId,int userId)
        {
            var vehicle = _context.Requests.Any(opt => opt.VehicleId == VehicleId && opt.UserId == userId);
            if (vehicle == true)
            {
                return true;
            }
            return false;
        }
        public async Task<ServiceResponse<RequestDTO>> CreateRequest(int userId, RequestDTO requestDto)
        {
            var request = _mapper.Map<Request>(requestDto);
            request.UserId = userId;
            if (UserAlreadyRequested(requestDto.VehicleId,userId) == true)
            {
                return new ServiceResponse<RequestDTO>
                {
                    Data = null,
                    Message = "You can not send another request to the same vehicle",
                    Success = false
                };
            }
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
            var request = await _context.Requests.Where(opt => opt.RequestId == requestId).FirstOrDefaultAsync();
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return new ServiceResponse<string>
            {
                Data = "Request Deleted",
                Message = "Deleted the request",
                Success = true
            };
        }
        public async Task<ServiceResponse<List<RequestDTO>>> GetAllRequest(int userId)
        {
            var requests = await _context.Requests.Where(opt => opt.UserId == userId).ToListAsync();
            var data = _mapper.Map<List<RequestDTO>>(requests);
            return new ServiceResponse<List<RequestDTO>>
            {
                Data = data,
                Message = "All Requests Has Listed",
                Success = true
            };
        }
        public async Task<ServiceResponse<RequestDTO>> GetRequest(int requestId)
        {
            var request = await _context.Requests.Where(opt => opt.RequestId == requestId).FirstOrDefaultAsync();
            var data = _mapper.Map<RequestDTO>(request);
            if (data != null)
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
        public async Task<ServiceResponse<RequestDTO>> UpdateRequest(int requestId, RequestDTO requestUpdate)
        {
            var request = await _context.Requests.Where(opt => opt.RequestId == requestId).FirstOrDefaultAsync();

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            
            var newRequest = _mapper.Map(requestUpdate, request);
            _context.Requests.Update(newRequest);
            await _context.SaveChangesAsync();

            var data = _mapper.Map<RequestDTO>(request);
            return new ServiceResponse<RequestDTO>
            {
                Data = data,
                Message = "The request updated successfully",
                Success = true
            };
        }

        public async Task<ServiceResponse<List<Request>>> RequestForCompanyList(int companyId)
        {
            ServiceResponse<List<Request>> _response = new ServiceResponse<List<Request>>();
            var response = await _context.Requests
                .Include(x=>x.Vehicle)
                .ThenInclude(x=>x.Company)
                .Where(x => x.Vehicle.CompanyId == companyId).ToListAsync();
            if (!response.Any())
            {
                _response.Success = false;
                _response.Message = "Your company is not any request";
                return _response;
            }

            _response.Success = true;
            _response.Data = response;
            return _response;
        
        }





    }
}