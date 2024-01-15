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

            public string Nom { get; set; }


            public string Prenom { get; set; }

            [Required]
            [Phone]
            public string NumeroTelephone { get; set; }

       
            public string Adresse { get; set; }

            public TypeClient Type { get; set; }
        }
}
