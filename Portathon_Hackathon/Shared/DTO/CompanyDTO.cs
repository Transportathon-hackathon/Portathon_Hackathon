using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portathon_Hackathon.Shared.DTO
{
    public class CompanyDTO
    {
        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "You have to add a Company Name Tom your Company")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage ="You have to add an image for your customers")]
        public string ImageUrl  { get; set; }
    }
}
