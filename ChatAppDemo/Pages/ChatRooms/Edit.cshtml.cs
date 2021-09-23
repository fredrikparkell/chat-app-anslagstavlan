using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChatAppDemo.Data;
using ChatAppDemo.Models;

namespace ChatAppDemo.Pages.ChatRooms
{
    public class EditModel : PageModel
    {
        private readonly ChatAppDemo.Data.ChatDbContext _context;

        public EditModel(ChatAppDemo.Data.ChatDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ChatRoomModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatRoomModelExists(ChatRoomModel.ChatRoomId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ChatRoomModelExists(int id)
        {
            return _context.ChatRooms.Any(e => e.ChatRoomId == id);
        }
    }
}
