using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Reflection.Metadata;
using System.Web;

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
        
        public byte[] Image { get; set; }
    }
}
