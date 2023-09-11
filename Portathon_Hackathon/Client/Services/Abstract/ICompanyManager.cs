using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Client.Services.Abstract
{
    public interface ICompanyManager
    {
        Task<ServiceResponse<CompanyDTO>> CreateCompany(CompanyDTO model);
        Task<ServiceResponse<List<CompanyDTO>>> GetAllCompany();
    }
}
