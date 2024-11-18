namespace AcademyWebsite.SignalR;

using AcademyWebsite.Data;
using AcademyWebsite.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
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
            .OrderBy(m => m.TimeStamp) // Order by time
            .Select(m => new
            {
                m.User,
                m.Text,
                TimeStamp = m.TimeStamp // Send DateTime directly
            })
            .ToListAsync();

        // Send previous messages to the caller (the user who connected)
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

        await Clients.All.SendAsync("ReceiveMessage", user, message, chatMessage.TimeStamp);
    }

    public override async Task OnConnectedAsync()
    {
        // Retrieve the last 50 messages (or whatever limit you want)
        var messages = _context.Messages
            .OrderBy(m => m.TimeStamp)
            .Take(20)
            .ToList();

        // Send previous messages to the connecting client
        await Clients.Caller.SendAsync("LoadMessages", messages);

        await base.OnConnectedAsync();
    }
}
