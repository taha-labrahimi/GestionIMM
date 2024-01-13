using System.ComponentModel.DataAnnotations;

namespace GestionIMM.Models
{
    public class Propriete
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public double Taille { get; set; }

        [Required]
        [StringLength(255)]
        public string Emplacement { get; set; }

        public string Caracteristiques { get; set; }

        public byte[] Image { get; set; }
    }
}
