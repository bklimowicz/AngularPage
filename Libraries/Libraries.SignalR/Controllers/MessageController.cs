﻿using System.Diagnostics.CodeAnalysis;
using Libraries.SignalR.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Libraries.SignalR.Controllers
{
    [ApiController]
    [Route("api/message")]
    public class MessageController : Controller
    {
        protected readonly IHubContext<MessageHub> _messageHub;
        public MessageController([NotNull] IHubContext<MessageHub> messageHub)
        {
            _messageHub = messageHub;
        }

        [HttpPost]
        public async Task<IActionResult> Create(MessagePost messagePost)
        {
            await _messageHub.Clients.All.SendAsync("sendToReact", $"The message \"{messagePost.Message}\" has been received.");

            return Ok();
        }

    }
    public class MessagePost
    {
        public virtual string Message { get; set; }
    }
}
