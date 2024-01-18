using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace GestionIMM.Models
{
    public class Utilisateur : IdentityUser
    {

        public string Nom { get; set; }

        public string Prenom { get; set; }
    }

}
