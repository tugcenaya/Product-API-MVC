using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Hubs
{
    public class SignalServer : Hub
    {
        public async Task SendProductUpdate(string message)
        {
            // Send the product update message to all clients
            await Clients.All.SendAsync("ReceiveProductUpdate", message);
        }
    }
}