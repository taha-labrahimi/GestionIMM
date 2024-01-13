using System.ComponentModel.DataAnnotations;

namespace GestionIMM.Models
{
    public class Propriete
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public double Taille { get; set; }
        public string Emplacement { get; set; }
        public string Caracteristiques { get; set; }
        public string Image { get; set; }
    }
}
