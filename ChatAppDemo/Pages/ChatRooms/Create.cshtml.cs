using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChatAppDemo.Data;
using ChatAppDemo.Models;

namespace ChatAppDemo.Pages.ChatRooms
{
    public class CreateModel : PageModel
    {
        private readonly ChatAppDemo.Data.ChatDbContext _context;

        public CreateModel(ChatAppDemo.Data.ChatDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ChatRoomModel ChatRoomModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ChatRooms.Add(ChatRoomModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
