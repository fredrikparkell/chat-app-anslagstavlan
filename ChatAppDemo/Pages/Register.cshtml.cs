using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ChatAppDemo.Data;
using ChatAppDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChatAppDemo.Pages
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ChatUserModel> signInManager;
        private readonly ChatDbContext chatContext;

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

        public RegisterModel(SignInManager<ChatUserModel> signInManager, ChatDbContext chatContext)
        {
            this.signInManager = signInManager;
            this.chatContext = chatContext;
        }

        public IActionResult OnGet()
        {
            if (signInManager.IsSignedIn(HttpContext.User))
            {
                return RedirectToPage("/ChatRooms/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if(Password == ConfirmPassword)
                {
                    int id = !chatContext.Users.Any() ? 1 : chatContext.Users.Last().ChatUserId + 1;
                    var newUser = new ChatUserModel()
                    {
                        UserName = Username,
                        ChatUserId = id
                    };

                    var createResult = await signInManager.UserManager.CreateAsync(newUser, Password);

                    if (createResult.Succeeded)
                    {
                        var signInResult = await signInManager.PasswordSignInAsync(Username, Password, false, false);

                        if (signInResult.Succeeded)
                        {
                            return RedirectToPage("/ChatRooms/Index");
                        }
                    }
                }
            }

            return Page();
        }
    }
}
