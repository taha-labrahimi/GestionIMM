using GestionIMM.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestionIMM.Data
{
    public class ApplicationDbContext : IdentityDbContext<Utilisateur>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> clients { get; set; }
        public DbSet<Propriete> proprietes { get; set; }
        public DbSet<Maintenance> maintenances { get; set; }
        public DbSet<ContratLocation> contratLocations { get; set; }
        public DbSet<TransactionVente> transactionVentes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Cela configure le schéma nécessaire pour Identity

            // Configuration des relations pour ContratLocation
            modelBuilder.Entity<ContratLocation>()
                .HasOne(cl => cl.Propriete)
                .WithMany() // Remplacez ceci si vous avez une collection de ContratLocation dans Propriete
                .HasForeignKey(cl => cl.ProprieteId)
                .OnDelete(DeleteBehavior.Restrict); // Configurez le comportement de suppression si nécessaire

            modelBuilder.Entity<ContratLocation>()
                .HasOne(cl => cl.Locataire)
                .WithMany() // Remplacez ceci si vous avez une collection de ContratLocation dans Client
                .HasForeignKey(cl => cl.LocataireId)
                .OnDelete(DeleteBehavior.Restrict); // Configurez le comportement de suppression si nécessaire

            // Ajoutez d'autres configurations de Fluent API ici pour d'autres entités et leurs relations

            // Exemple pour la classe TransactionVente
            modelBuilder.Entity<TransactionVente>()
                .HasOne(tv => tv.Propriete)
                .WithMany()
                .HasForeignKey(tv => tv.ProprieteId)
            .OnDelete(DeleteBehavior.Restrict); // Adaptez le comportement de suppression selon les besoins de votre application

            modelBuilder.Entity<TransactionVente>()
                .HasOne(tv => tv.Client)
                .WithMany() // Remplacez ceci si vous avez une collection de TransactionVente dans Client
                .HasForeignKey(tv => tv.AcheteurId)
                .OnDelete(DeleteBehavior.Restrict); // Adaptez le comportement de suppression selon les besoins de votre application

            // Continuez avec les configurations supplémentaires si nécessaire
        }
    }
    
}