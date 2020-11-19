using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CollectionApp.Hubs;
using CollectionLogic;
using CollectionLogic.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CollectionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IHubContext<NotificationHub> _notificationHubContext;
        private readonly IHubContext<NotificationUserHub> _notificationUserHubContext;
        private readonly IUserConnectionManager _userConnectionManager;

        public AuthController(IHubContext<NotificationHub> notificationHubContext, IHubContext<NotificationUserHub> notificationUserHubContext, IUserConnectionManager userConnectionManager)
        {
            _notificationHubContext = notificationHubContext;
            _notificationUserHubContext = notificationUserHubContext;
            _userConnectionManager = userConnectionManager;
            notificationController = new NotificationController(_notificationHubContext, _notificationUserHubContext, _userConnectionManager);
        }

        private readonly Auth cont = new Auth();
        private readonly NotificationController notificationController;

        [HttpGet]
        public IActionResult Get()
        {
            UserEntitiy user = cont.Login();
            if (user != null)
            {
                //await notificationController.GetAsync("user", user.Id);
                return Ok(user);
            }
            return Unauthorized(new { message = "Username or password is incorrect" });
        }
    }
}
