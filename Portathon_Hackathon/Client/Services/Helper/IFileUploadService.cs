using BlazorInputFile;
using Microsoft.AspNetCore.Components.Forms;

namespace Portathon_Hackathon.Client.Services.Helper
{
    public interface IFileUploadService
    {

        Task<bool> FileUploadAsync(IFileListEntry file, string folderName,int objectType);

    }
}
