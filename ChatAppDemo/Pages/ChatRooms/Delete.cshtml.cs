using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChatAppDemo.Data;
using ChatAppDemo.Models;

namespace ChatAppDemo.Pages.ChatRooms
{
    public class DeleteModel : PageModel
    {
        private readonly ChatAppDemo.Data.ChatDbContext _context;

        public DeleteModel(ChatAppDemo.Data.ChatDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ChatRoomModel ChatRoomModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChatRoomModel = await _context.ChatRooms.FirstOrDefaultAsync(m => m.ChatRoomId == id);

            if (ChatRoomModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChatRoomModel = await _context.ChatRooms.FindAsync(id);

            if (ChatRoomModel != null)
            {
                _context.ChatRooms.Remove(ChatRoomModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
