using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portathon_Hackathon.Shared.DTO
{
    public class VehicleDTO
    {
        public VehicleTypes VehicleType { get; set; }
        public decimal Capacity { get; set; }
        public string TechnicDetail { get; set; }
        public string PlateNumber { get; set; }
        public string ChauffeurName { get; set; }
    }


    public enum VehicleTypes
    {
        Truck,
        Lory

    }
}
