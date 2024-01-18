// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using GestionIMM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionIMM.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<Utilisateur> _userManager;
        private readonly SignInManager<Utilisateur> _signInManager;

        public IndexModel(
            UserManager<Utilisateur> userManager,
            SignInManager<Utilisateur> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            [Required]
            [Display(Name = "Nom d'utilisateur")]
            public string Username { get; set; }
            [Required]
            [Display(Name = "Prénom")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Nom")]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Rôle")]
            public string Role { get; set; }

            [Phone]
            [Display(Name = "Numéro de téléphone")]
            public string PhoneNumber { get; set; }

        }

        private async Task LoadAsync(Utilisateur user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var userRole = roles.FirstOrDefault() ?? "Aucun rôle";
            

            Username = userName;

            Input = new InputModel
            {
                Username = user.UserName,
                FirstName = user.Prenom,
                LastName = user.Nom,
                Email = email,
                PhoneNumber = phoneNumber,
                Role = userRole
                
            };
        }
        public SelectList RoleSelectList { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Impossible de charger l'utilisateur avec l'ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            RoleSelectList = new SelectList(new[] { "Administrateur", "AgentImmobilier" });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Impossible de charger l'utilisateur avec l'ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user); // Rechargez les informations de l'utilisateur si le modèle n'est pas valide
                return Page();
            }

            // Mettre à jour le prénom et le nom
            user.Prenom = Input.FirstName;
            user.Nom = Input.LastName;

            if (Input.Username != user.UserName) // Vérifiez si le nom d'utilisateur a changé
            {
                var setUsernameResult = await _userManager.SetUserNameAsync(user, Input.Username);
                if (!setUsernameResult.Succeeded)
                {
                    StatusMessage = "Une erreur inattendue s'est produite lors de la mise à jour du nom d'utilisateur.";
                    return RedirectToPage();
                }
            }
            // Mettre à jour l'email
            var email = await _userManager.GetEmailAsync(user);
            if (Input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    StatusMessage = "Une erreur inattendue s'est produite lors de la mise à jour de l'email.";
                    return RedirectToPage();
                }
            }

            // Mettre à jour le numéro de téléphone
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Une erreur inattendue s'est produite lors de la mise à jour du numéro de téléphone.";
                    return RedirectToPage();
                }
            }

            // Mettre à jour le rôle si nécessaire
            var currentRoles = await _userManager.GetRolesAsync(user);
            if (!currentRoles.Contains(Input.Role))
            {
                var removeRolesResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!removeRolesResult.Succeeded)
                {
                    StatusMessage = "Une erreur inattendue s'est produite lors de la suppression des rôles existants.";
                    return RedirectToPage();
                }

                var addRoleResult = await _userManager.AddToRoleAsync(user, Input.Role);
                if (!addRoleResult.Succeeded)
                {
                    StatusMessage = "Une erreur inattendue s'est produite lors de l'ajout du nouveau rôle.";
                    return RedirectToPage();
                }
            }

            // Persistez les changements dans la base de données
            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                StatusMessage = "Une erreur inattendue s'est produite lors de la mise à jour du profil.";
                return RedirectToPage();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Votre profil a été mis à jour";
            return RedirectToPage();
        }

    }
}
