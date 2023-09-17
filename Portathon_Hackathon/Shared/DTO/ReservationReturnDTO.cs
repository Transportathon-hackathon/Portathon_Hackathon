using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portathon_Hackathon.Shared.DTO
{
    public class ReservationReturnDTO
    {
        public int ReservationId { get; set; }

        public int RequestId { get; set; }
        public string ReservationCase { get; set; }
        public DateTime ReservationDate { get; set; } = DateTime.Now;
        public string OtherDetails { get; set; }
        public int CompanyId { get; set; }
        public bool IsFinished { get; set; }
        public UserDto User { get; set; }
        public RequestDTO Request { get; set; }
    }
}
