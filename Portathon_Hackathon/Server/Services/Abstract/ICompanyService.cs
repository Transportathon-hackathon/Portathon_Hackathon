
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Services.Abstract
{
    public interface ICompanyService
    {
        Task<ServiceResponse<CompanyDTO>> CreateCompany(CompanyDTO request);
        Task<ServiceResponse<List<Company>>> GetCompanyFeatures(int companyId);
    }
}
