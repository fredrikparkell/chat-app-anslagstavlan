using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ChatAppDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChatAppDemo.Pages.ChatRooms
{
    public class AccountModel : PageModel
    {
        private readonly SignInManager<ChatUserModel> signInManager;

        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }

        public AccountModel(SignInManager<ChatUserModel> signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                // Validera gammalt lösenord
                var user = await signInManager.UserManager.GetUserAsync(HttpContext.User);

                var oldPasswordOk = await signInManager.UserManager.CheckPasswordAsync(user, OldPassword);

                // Validera nytt lösenord

                PasswordValidator<ChatUserModel> validator = new PasswordValidator<ChatUserModel>();

                var result = await validator.ValidateAsync(signInManager.UserManager, user, NewPassword);

                // Byt lösenord

                if (oldPasswordOk && result.Succeeded)
                {
                    await signInManager.UserManager.ChangePasswordAsync(user, OldPassword, NewPassword);

                    return RedirectToPage("/ChatRooms/Index");
                }
            }

            return Page();
        }

        public IActionResult OnPostSignOut()
        {
            signInManager.SignOutAsync();

            // HttpContext.User

            return RedirectToPage("/Index");
        }
    }
}
