using AutoMapper;
using Portathon_Hackathon.Server.Context;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Services.Concrete
{
    public class VehicleService : IVehicleService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public VehicleService(IMapper mapper,ApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<VehicleDTO>> CreateVehicle(VehicleDTO request, int companyId)
        {
            var objDTO = _mapper.Map<Vehicle>(request);
            ServiceResponse<VehicleDTO> response = new ServiceResponse<VehicleDTO>();
            objDTO.CompanyId = companyId;
            if (objDTO != null )
            {
                _context.Vehicles.Add(objDTO);
                if(await _context.SaveChangesAsync() > 0)
                {
                    response.Success = true;
                    response.Message = "Vehicle Created";
                    response.Data = request;
                    return response;
                }
            }
            response.Success = false;
            response.Message = "Vehicle is not Created";
            return response;

        }
    }
}
