using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portathon_Hackathon.Shared.Entities
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public int RequestId { get; set; }
        public Request Request { get; set; }
        public DateTime ReservationDate { get; set; }       
        public string OtherDetails { get; set; }  
        
        public Evaluation Evaluation { get; set; }



    }
}
