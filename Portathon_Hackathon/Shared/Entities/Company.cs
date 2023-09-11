using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Portathon_Hackathon.Shared.Entities
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }  
        public string CompanyName { get; set; }
<<<<<<< HEAD
        public string? ImageUrl { get; set; }    
=======
>>>>>>> 8f511c3d449a0a715dea88968ec387026f2810c6
        public List<Vehicle> Vehicles { get; set; } 

    } 
}
