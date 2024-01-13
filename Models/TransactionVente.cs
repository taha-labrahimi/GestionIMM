using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionIMM.Models
{
    public class TransactionVente
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Propriete")]
        public int ProprieteId { get; set; }
        public Propriete Propriete { get; set; }

        [ForeignKey("Client")]
        public int AcheteurId { get; set; }
        public Client Acheteur { get; set; }

        [Required]
        public DateTime DateTransaction { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Montant { get; set; }
    }
}
