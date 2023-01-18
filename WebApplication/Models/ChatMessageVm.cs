using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ChatMessageVm
    {
        public Guid UserId { get; set; }
        public string Sender { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
    }
}
