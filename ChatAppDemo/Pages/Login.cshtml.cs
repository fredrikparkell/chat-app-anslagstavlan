using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ChatAppDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChatAppDemo.Pages
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ChatUserModel> signInManager;

        [Required(ErrorMessage = "Username is missing")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is missing")]
        public string Password { get; set; }

        //public string ErrorMessage { get; set; }

        public LoginModel(SignInManager<ChatUserModel> signInManager)
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
                // Sign in user
                var result = await signInManager.PasswordSignInAsync(Username, Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToPage("/ChatRooms/Index");
                }
            }

            return Page();
        }
    }
}
