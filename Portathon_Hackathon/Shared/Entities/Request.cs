﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portathon_Hackathon.Shared.Entities
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        public int UserId { get; set; } 
        public User User { get; set; }  
        public string RequestType { get; set; } 
        public string RequestDetail { get; set; }   
        public string ContactConfirmation { get; set; } 

    }
}
