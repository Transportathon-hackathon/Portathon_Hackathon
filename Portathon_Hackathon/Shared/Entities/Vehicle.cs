using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portathon_Hackathon.Shared.Entities
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Capacity { get; set; }    
        public string TechnicDetail { get; set; }
        public string PlateNumber { get; set; } 
        public string ChauffeurName { get; set; }   
        public int CompanyId { get; set; }  
        public string VehicleType { get; set; }
        [JsonIgnore]
        public Company Company { get; set; }
        [JsonIgnore]
        public List<Request> requests { get; set; }
        public List<CrewMember> CrewMembers { get; set; }
        //public int ChauffeurId { get; set; }    
        //public Chauffeur Chauffeur { get; set; }

    }

 
}
