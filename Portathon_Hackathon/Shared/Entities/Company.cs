using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portathon_Hackathon.Shared.Entities
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }  
        public string CompanyName { get; set; }
        public List<Vehicle> Vehicles { get; set; } 

    } 
}
