using Portathon_Hackathon.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portathon_Hackathon.Shared.DTO
{
    public class ReservationDTO
    {
        public int RequestId { get; set; }
        public string OtherDetails { get; set; }
        public ReservationCase ReservationCase { get; set; }
    }

    public enum ReservationCase 
    {
        Rejected,
        Accepted
    }
}
