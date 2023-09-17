using Microsoft.EntityFrameworkCore;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Reservation> Reservations { get; set; }    
        public DbSet<CrewMember> CrewMembers { get; set; }    
        public DbSet<Company> Companies { get; set; }
        public DbSet<Request> Requests { get; set; }    
        public DbSet<Evaluation> Evaluations { get; set; }    
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
