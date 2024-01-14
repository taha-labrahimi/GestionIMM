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

        [ForeignKey("Client")]
        public int LocataireId { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime DateFin { get; set; }

        public decimal PaiementMensuel { get; set; }

        public Boolean Disponibilite { get; set; }
    }
}
