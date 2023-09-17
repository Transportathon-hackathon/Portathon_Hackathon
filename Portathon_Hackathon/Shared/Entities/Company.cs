using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
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
        [ForeignKey("User")]
        public int UserId { get; set; }
        [AllowNull]
        public User User { get; set; }
        public string CompanyName { get; set; }
        public string? ImageUrl { get; set; }    
        public List<Vehicle> Vehicles { get; set; }
        public List<Evaluation> Evaluations { get; set; }

    } 
}
