using System.ComponentModel.DataAnnotations;

namespace GestionIMM.Models
{

   
        // Définition de l'énumération pour les types de clients
        public enum TypeClient
        {
            Acheteur,
            Vendeur,
            Locataire
        }

        public class Client
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [StringLength(100)]
            public string Nom { get; set; }

            [Required]
            [StringLength(100)]
            public string Prenom { get; set; }

            [Required]
            [Phone]
            public string NumeroTelephone { get; set; }

            [Required]
            [StringLength(255)]
            public string Adresse { get; set; }

            public TypeClient Type { get; set; }
        }
}
