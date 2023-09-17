using System.ComponentModel.DataAnnotations;

namespace Portathon_Hackathon.Shared.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public int SenderId { get; set; }   
        public int ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime TimeSpan { get; set; } = DateTime.UtcNow;
        public List<User> Users { get; set; }   

    
    
    }
}
