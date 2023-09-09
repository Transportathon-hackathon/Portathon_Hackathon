using Portathon_Hackathon.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portathon_Hackathon.Shared.DTO
{
    public class RequestDTO
    {
        public int UserId { get; set; }
        public RequestType RequestType { get; set; }
        public string RequestDetail { get; set; }
        public string ContactConfirmation { get; set; }
    }
    public enum RequestType 
    {
        HometoHomeTransport,
        OfficeTransport,
        LargeCapacityTransport,
        MostlyObjectsTransport
    }

}
