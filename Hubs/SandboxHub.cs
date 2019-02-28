using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WebApp.Hubs
{
    public class SandboxHub : Hub
    {
        public static int connectionCounter;

        public async Task NewMessage(string message)
        {
            await Clients.All.SendAsync("messageReceived", message);
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            connectionCounter++;
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
            connectionCounter--;
        }
    }
}
