namespace AcademyWebsite.SignalR
{
    using AcademyWebsite.Data;
    using AcademyWebsite.Models;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class ChatHub : Hub
    {
        private readonly AcademyWebsiteContext _context;

        public ChatHub(AcademyWebsiteContext context)
        {
            _context = context;
        }
        public async Task LoadMessages()
        {
            var messages = await _context.Messages
                .OrderByDescending(m => m.TimeStamp)
                .Take(10)
                .OrderBy(m => m.TimeStamp)
                .Select(m => new
                {
                    m.User,
                    m.Text
                })
                .ToListAsync();


            await Clients.Caller.SendAsync("LoadMessages", messages);
        }




        public async Task SendMessage(string user, string message)
        {
            var chatMessage = new Message
            {
                User = user,
                Text = message,
                TimeStamp = DateTime.UtcNow
            };

            _context.Messages.Add(chatMessage);
            await _context.SaveChangesAsync();

            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }


        public override async Task OnConnectedAsync()
        {
            var messages = await _context.Messages
                .OrderByDescending(m => m.TimeStamp)
                .Take(10)
                .Select(m => new
                {
                    m.User,
                    m.Text,
                    TimeStamp = m.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss")
                })
                .ToListAsync();

            messages.Reverse();

            await Clients.Caller.SendAsync("LoadMessages", messages);

            await base.OnConnectedAsync();
        }

    }
}
