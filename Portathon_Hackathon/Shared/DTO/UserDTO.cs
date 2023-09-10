using Portathon_Hackathon.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portathon_Hackathon.Shared.DTO
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public string UserType { get; set; }
    }
}
