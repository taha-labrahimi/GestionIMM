using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionIMM.Models
{
    public class ContratLocation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Propriete")]
        public int ProprieteId { get; set; }
        public Propriete Propriete { get; set; }

        [ForeignKey("Client")]
        public int LocataireId { get; set; }
        public Client Locataire { get; set; }

        [Required]
        public DateTime DateDebut { get; set; }

        [Required]
        public DateTime DateFin { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PaiementMensuel { get; set; }
    }
}
