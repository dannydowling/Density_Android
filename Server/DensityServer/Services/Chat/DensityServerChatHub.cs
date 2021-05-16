using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.SignalR;

namespace DensityServer.Hubs
{
    public class DensityServerChatHub : Hub
    {
        public void Send(string message, string associates)
        {
            Clients.Group(associates).SendAsync
                (
                Context.User.Identity.Name + ": " + message
                );
        }
    }
}