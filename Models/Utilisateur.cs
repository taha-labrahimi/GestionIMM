using System.ComponentModel.DataAnnotations;
namespace GestionIMM.Models
{
    public class Utilisateur
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NomUtilisateur { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }

        [Required]
        public RoleUtilisateur Role { get; set; }

        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Nom { get; set; }

        [StringLength(50)]
        public string Prenom { get; set; }
    }

    public enum RoleUtilisateur
    {
        Administrateur,
        AgentImmobilier
    }
}
