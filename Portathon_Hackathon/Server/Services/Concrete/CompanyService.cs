using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portathon_Hackathon.Server.Context;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Services.Concrete
{
    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CompanyService( IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<CompanyDTO>> CreateCompany(CompanyDTO request)
        {
            var objDTO = _mapper.Map<Company>(request);
            ServiceResponse<CompanyDTO> response = new ServiceResponse<CompanyDTO>();
            _context.Companies.Add(objDTO);
            if(await _context.SaveChangesAsync() > 0)
            {
                response.Success = true;
                response.Message = "Company is created";
                response.Data = request;
                return response;
            }
            response.Success = false;
            response.Message = "Company is not created";
            response.Data = null;
            return response;
        }

        public async Task<ServiceResponse<List<CompanyDTO>>> GetAllCompanies()
        {
            var result = await _context.Companies.ToListAsync();
            ServiceResponse<List<CompanyDTO>> _response = new ServiceResponse<List<CompanyDTO>>(); 
            if(result != null)
            {
                var objDTO = _mapper.Map<List<CompanyDTO>>(result);
                _response.Data = objDTO;
                _response.Success = true;
                _response.Message = "Listed";
                return _response;
            }
            return _response;

        }

        public async Task<ServiceResponse<List<Company>>> GetCompanyFeatures(int companyId)
        {
            ServiceResponse<List<Company>> _response = new ServiceResponse<List<Company>>();
            var result = await _context.Companies
                .Include(x => x.Vehicles)
                .ThenInclude(x=>x.CrewMembers)
                .Where(x => x.CompanyId == companyId)
                .ToListAsync();
            List<Company> resultList = new List<Company>(); 
           
            if(result.Count != 0)
            {
                foreach (var item in result)
                {
                    resultList.Add(item);
                }
                _response.Success = true;
                _response.Message = "Listed";
                _response.Data = resultList;
                return _response;
            }
            _response.Success = false;
            _response.Message = "Fail";
            return _response;
            
          
        }
    }
}
