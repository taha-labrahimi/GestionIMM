using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionIMM.Models
{
    public class Maintenance
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Propriete")]
        public int ProprieteId { get; set; }
        public Propriete Propriete { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public DateTime DateDemande { get; set; }
    }
}
