using GestionIMM.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestionIMM.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Client> clients { get; set; }
        public DbSet<Propriete> proprietes { get; set; }
        public DbSet<Utilisateur> utilisateurs { get; set; }
    }
}
