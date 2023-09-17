using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portathon_Hackathon.Shared.DTO
{
    public class MessageDTO
    {
        public int? SenderId { get; set; }
        [Required]
        public int ReceiverId { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime TimeSpan { get; set; }
    }
}
