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

        public  async Task<ServiceResponse<bool>> CompanyCreatedOrNot(int userId)
        {
            var user =await _context.Users.Where(opt => opt.Id == userId).FirstOrDefaultAsync();

            if(user.UserType == "Company")
            {
                var company =_context.Companies.Where(opt => opt.UserId == userId).Any();
                if(company ==true)
                {
                    return new ServiceResponse<bool>
                    {
                        Data = true,
                        Message = "You already created your account!",
                        Success = true
                    };
                }
                else
                {

                    return new ServiceResponse<bool>
                    {
                        Data = false,
                        Success = false,
                        Message = "Should complete the company create operation!"
                    };
                }
            }
            return new ServiceResponse<bool>
            {
                Data = false,
                Success = false,
                Message = "User type can not create a company"
            }; ;
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

        public async Task<ServiceResponse<Company>> GetCompanyFeatures(int companyId)
        {
            ServiceResponse<Company> _response = new ServiceResponse<Company>();
            var result = await _context.Companies
                .Include(x => x.Vehicles)
                .ThenInclude(x=>x.CrewMembers)
                .Where(x => x.CompanyId == companyId)
                .FirstOrDefaultAsync();
           
           
            if(result != null)
            {
                _response.Success = true;
                _response.Message = "Company Getted";
                _response.Data = result;
                return _response;
            }
            _response.Success = false;
            _response.Message = "Fail";
            return _response;
            
          
        }

        public async Task<ServiceResponse<int>> GetCompanyIdByUserId(int userId)
        {
            var company = await _context.Companies.Where(opt => opt.UserId == userId).FirstOrDefaultAsync();
            if(company == null)
            {
                return new ServiceResponse<int>
                {
                    Data =  0,
                    Message = "There is no company with this userId",
                    Success = false
                };
            }
            return new ServiceResponse<int> 
            {
                Data = company.CompanyId,
                Message  = "Company Id getted Successfully",
                Success = true
            }; 
        }
    }
}
