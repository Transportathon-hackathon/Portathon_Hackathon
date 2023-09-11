using Microsoft.AspNetCore.Components.Forms;

namespace Portathon_Hackathon.Client.Services.Abstract
{
    public interface IFileManager
    {
        Task<string> CreateImage(IBrowserFile file);
    }
}
