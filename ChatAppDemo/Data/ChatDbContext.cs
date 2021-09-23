using ChatAppDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppDemo.Data
{
    public class ChatDbContext : IdentityDbContext<ChatUserModel>
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
        {

        }

        public DbSet<ChatMessageModel> ChatMessages { get; set; }
        public DbSet<ChatRoomModel> ChatRooms { get; set; }
    }
}
