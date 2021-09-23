using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppDemo.Models
{
    public class ChatMessageModel
    {
        [Key]
        public int ChatMessageId { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public int ChatRoomId { get; set; } // Foreign key - what room was this posted in?
        public ChatRoomModel ChatRoom { get; set; } // Don't forget .Include(x => x.ChatRoom)
        public int ChatUserId { get; set; } // Foreign key - what user wrote this message?
        public ChatUserModel ChatUser { get; set; } // Don't forget .Include(x => x.ChatUser)
    }
}
