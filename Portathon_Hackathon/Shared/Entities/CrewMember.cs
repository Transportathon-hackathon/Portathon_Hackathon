using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portathon_Hackathon.Shared.Entities
{
    public class CrewMember
    {
        [Key]
        public int Id { get; set; } 
        
        public string MemberName { get; set; }

        public int VehicleId { get; set; }
        [JsonIgnore]
        public Vehicle Vehicle { get; set; }
     
    }
}
