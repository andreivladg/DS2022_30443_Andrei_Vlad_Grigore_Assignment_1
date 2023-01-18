using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(ChatMessageVm chatVm)
        {
            await Clients.All.SendAsync("ReceiveChat", chatVm);
        }
    }
}
