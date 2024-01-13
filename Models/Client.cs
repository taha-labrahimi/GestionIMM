using System.ComponentModel.DataAnnotations;

namespace GestionIMM.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string NumeroTelephone { get; set; }
        public string Adresse { get; set; }
        public string Type { get; set; }
    }
}
