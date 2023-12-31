﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portathon_Hackathon.Shared.Entities
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public int RequestId { get; set; }
        public string ReservationCase { get; set; }
        public DateTime ReservationDate { get; set; } = DateTime.Now;      
        public string OtherDetails { get; set; }
        public bool IsReservationFinish { get; set; } = false;
        public Request Request { get; set; }
    }
}
