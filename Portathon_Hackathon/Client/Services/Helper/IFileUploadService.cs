using BlazorInputFile;
using Microsoft.AspNetCore.Components.Forms;

namespace Portathon_Hackathon.Client.Services.Helper
{
    public interface IFileUploadService
    {

<<<<<<< HEAD
        Task<bool> FileUploadAsync(IFileListEntry file, string folderName,int type);
=======
        Task<bool> FileUploadAsync(IFileListEntry file, string folderName,int fileContent);
>>>>>>> b7796df013d6e994696c8439fae0c7b728fcec6c

    }
}
