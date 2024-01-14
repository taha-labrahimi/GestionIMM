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

        [ForeignKey("Client")]
        public int AcheteurId { get; set; }

        public DateTime DateTransaction { get; set; }

        public decimal Montant { get; set; }
    }
}
