﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portathon_Hackathon.Shared.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string  Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public string UserType { get; set; } = "User";
        [JsonIgnore]
        public Company Company { get; set; }
        public List<Request> Requests { get; set; }
        public List<Message> Messages { get; set; }
    }

   


}
