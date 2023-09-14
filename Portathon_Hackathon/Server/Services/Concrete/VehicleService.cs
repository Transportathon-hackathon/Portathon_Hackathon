using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portathon_Hackathon.Server.Context;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;
using System.ComponentModel.Design;

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

        public async Task<ServiceResponse<string>> DeleteVehicle(int vehicleId)
        {

            var vehicle = await _context.Vehicles.Where(opt => opt.VehicleId == vehicleId).FirstOrDefaultAsync();
            
             if(vehicle == null)
             {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Deleting Opearation Has Failed",
                    Data = "A problem occured while looking for the vehicle"
                };
             }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return new ServiceResponse<string>
            {
                Success = true,
                Message = "You have deleted the Vehicle Successfully"
            };
     
        }

        public async Task<ServiceResponse<List<VehicleReturnDTO>>> GetAllVehicles()
        {
            var vehicles = await _context.Vehicles.Include(opt => opt.Company).ToListAsync();
            var responseData = _mapper.Map<List<VehicleReturnDTO>>(vehicles);

            if (vehicles is null)
            {
                return new ServiceResponse<List<VehicleReturnDTO>>
                {
                    Data = null,
                    Message = "There is no vehicle in the Platform yet",
                    Success = false
                };
            }
            return new ServiceResponse<List<VehicleReturnDTO>>
            {
                Data = responseData,
                Success = true,
                Message = "All vehicles is listed"
            };
        }

        public async Task<ServiceResponse<List<VehicleDTO>>> GetAllVehiclesByCompanyId(int companyId)
        {
            var vehicles =await  _context.Vehicles.Where(opt => opt.CompanyId == companyId).ToListAsync();
            var responseData = _mapper.Map<List<VehicleDTO>>(vehicles);
            if(vehicles is null )
            {
                return new ServiceResponse<List<VehicleDTO>>
                {
                    Data = null,
                    Message ="There is no vehicle in this copmany",
                    Success = false
                };
            }
            return new ServiceResponse<List<VehicleDTO>>
            {
                Data = responseData,
                Success = true,
                Message = "All vehicles is listed"
            };
        }

        public async Task<ServiceResponse<VehicleDTO>> GetVehicleById(int vehicleId)
        {
            var vehicle = await _context.Vehicles.Where(opt => opt.VehicleId == vehicleId).FirstOrDefaultAsync();
            var responseData = _mapper.Map<VehicleDTO>(vehicle);
            if (vehicle is null)
            {
                return new ServiceResponse<VehicleDTO>
                {
                    Data = null,
                    Message = "The vehicle could not found",
                    Success = false
                };
            }
            return new ServiceResponse<VehicleDTO>
            {
                Data = responseData,
                Success = true,
                Message = "The Vehicle has found"
            };
        }

        public async Task<ServiceResponse<VehicleDTO>> UpdateVehicle(int vehicleId,VehicleDTO dto)
        {
            var vehicle =await _context.Vehicles.Where(opt => opt.VehicleId == vehicleId).FirstOrDefaultAsync();

            if (vehicle == null)
            {
                return new ServiceResponse<VehicleDTO>
                {
                    Data = null,
                    Success = false,
                    Message = "The update Operation Failed"
                };
            }
            var objDTO = _mapper.Map(dto, vehicle);
            //objDTO.VehicleId = vehicleId;
            _context.Vehicles.Update(objDTO);
            await _context.SaveChangesAsync();
            
            var vehicleDTO = _mapper.Map<VehicleDTO>(vehicle);


                return new ServiceResponse<VehicleDTO>
                {
                    Data = vehicleDTO,
                    Success = true,
                    Message = "The update Operation Has succeded"
                };
        }
    }
}
