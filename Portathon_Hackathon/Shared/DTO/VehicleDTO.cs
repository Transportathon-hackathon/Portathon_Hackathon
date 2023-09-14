using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portathon_Hackathon.Shared.DTO
{
    public class VehicleDTO
    {
        public VehicleTypes VehicleType { get; set; }
        public decimal Capacity { get; set; }
        [Required(ErrorMessage ="Technic Detail is Required")]
        public string TechnicDetail { get; set; }
        [Required(ErrorMessage = "Plate Number is Required")]
        public string PlateNumber { get; set; }
        public string ImageUrl { get; set; }
        public string ChauffeurName { get; set; }
    }


    public enum VehicleTypes
    {
        Truck,
        Lory

    }
}
