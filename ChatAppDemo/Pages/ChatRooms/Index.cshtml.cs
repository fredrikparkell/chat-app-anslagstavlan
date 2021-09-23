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
    public class IndexModel : PageModel
    {
        private readonly ChatAppDemo.Data.ChatDbContext _context;

        public IndexModel(ChatAppDemo.Data.ChatDbContext context)
        {
            _context = context;
        }

        public IList<ChatRoomModel> ChatRoomModel { get;set; }

        public async Task OnGetAsync()
        {
            ChatRoomModel = await _context.ChatRooms.ToListAsync();
        }
    }
}
