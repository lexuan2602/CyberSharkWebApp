using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TEST_CRUD.Services.ChatHub
{
    public class ChatHub : Hub
    {
        // Dictionary to store messages for each user
        private static Dictionary<string, List<string>> userMessages = new Dictionary<string, List<string>>();

        public async Task SendMessage(int userId, string message)
        {
            try
            {
                // Send the message to the specified user
                await Clients.User(userId.ToString()).SendAsync("ReceiveMessage", message);

                // Store the message for the user
                if (!userMessages.ContainsKey(userId.ToString()))
                {
                    userMessages[userId.ToString()] = new List<string>();
                }

                userMessages[userId.ToString()].Add(message);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.Error.WriteLine($"Error sending message: {ex.ToString()}");
            }
        }

        public async Task GetMessages(int userId)
        {
            try
            {
                // Retrieve messages for the user
                if (userMessages.ContainsKey(userId.ToString()))
                {
                    var messages = userMessages[userId.ToString()];
                    await Clients.User(userId.ToString()).SendAsync("ReceiveMessages", messages);
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.Error.WriteLine($"Error getting messages: {ex.ToString()}");
            }
        }

        public override async Task OnConnectedAsync()
        {
            var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                // Add the connected user to the "Clients" group
                await Groups.AddToGroupAsync(Context.ConnectionId, "Clients");
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Remove the disconnected user from the "Clients" group
            var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Clients");
            }
        }

        public async Task RegisterAgent()
        {
            // Add the connected agent to the "Agents" group
            await Groups.AddToGroupAsync(Context.ConnectionId, "Agents");
        }

        public async Task RegisterClient()
        {
            // Add the connected client to the "Clients" group
            await Groups.AddToGroupAsync(Context.ConnectionId, "Clients");
        }
    }
}
