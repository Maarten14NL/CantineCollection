using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollectionApp.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CollectionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {

        private readonly IHubContext<NotificationHub> _notificationHubContext;
        private readonly IHubContext<NotificationUserHub> _notificationUserHubContext;
        private readonly IUserConnectionManager _userConnectionManager;

        public NotificationController(IHubContext<NotificationHub> notificationHubContext, IHubContext<NotificationUserHub> notificationUserHubContext, IUserConnectionManager userConnectionManager)
        {
            _notificationHubContext = notificationHubContext;
            _notificationUserHubContext = notificationUserHubContext;
            _userConnectionManager = userConnectionManager;
        }

        [HttpGet("{type}")]
        public async Task GetAsync(string type, int? id = null)
        {
            Notification notification = new Notification()
            {
                Title = "Order geüpdatet",
                Message = "Hallo dit is een melding",
                Icon = "Yes boys",
                Type = "info"
            };

            switch (type)
            {
                case "user":
                default:
                    await SendToUserAsync(notification);
                    break;

            } 
        }

        private async Task SendToUserAsync(Notification notification)
        {
            foreach (var connectionId in _userConnectionManager.GetUserConnections("1"))
            {
                await _notificationUserHubContext.Clients.Client(connectionId).SendAsync("sendToUser", notification);
            }
        }
    }
}
