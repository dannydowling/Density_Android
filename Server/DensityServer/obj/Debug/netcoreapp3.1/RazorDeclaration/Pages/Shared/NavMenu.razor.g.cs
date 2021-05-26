// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace DensityServer.Pages.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using Microsoft.AspNetCore.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using DensityServer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using DensityServer.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using DensityServer.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Shared\NavMenu.razor"
using DensityServer.Server.Services;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 96 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Shared\NavMenu.razor"
        bool collapseNavMenu = true;
        string NavMenuCssClass => collapseNavMenu ? "collapse" : null;
        void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        bool chatting = false;
        string username = null;
        ChatClient client = null;
        string message = null;
        string newMessage = null;
        List<Message> messages = new List<Message>();


        async Task Chat()
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                message = "Please enter a name";
                return;
            };

            try
            {

                messages.Clear();

                client = new ChatClient(username);
                client.MessageReceived += MessageReceived;
                Console.WriteLine("Chat starting...");
                await client.StartAsync();
                Console.WriteLine("Chat started");

                chatting = true;
            }
            catch (Exception e)
            {
                message = $"ERROR: Failed to start chat client: {e.Message}";
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }


        void MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine($"Chat: receive message {e.Username}: {e.Message}");
            bool isMine = false;
            if (!string.IsNullOrWhiteSpace(e.Username))
            {
                isMine = string.Equals(e.Username, username, StringComparison.CurrentCultureIgnoreCase);
            }

            var newMsg = new Message(e.Username, e.Message, isMine);
            messages.Add(newMsg);

            // inform viewcontroller that the UI needs updating
            StateHasChanged();
        }

        async Task DisconnectAsync()
        {
            if (chatting)
            {
                await client.StopAsync();
                client = null;
                message = "Chat ended";
                chatting = false;
            }
        }

        async Task SendAsync()
        {
            if (chatting && !string.IsNullOrWhiteSpace(newMessage))
            {
                await client.SendAsync(newMessage);
                newMessage = "";
            }
        }

    class Message
    {
        public Message(string username, string body, bool mine)
        {
            Username = username;
            Body = body;
            Mine = mine;
        }

        public string Username { get; set; }
        public string Body { get; set; }
        public bool Mine { get; set; }


        public string CSS
        {
            get
            {
                return Mine ? "sent" : "received";
            }
        }
    } 

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navigationManager { get; set; }
    }
}
#pragma warning restore 1591
