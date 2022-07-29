using System.Diagnostics.CodeAnalysis;
using Libraries.SignalR.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Libraries.SignalR.Controllers
{
    [ApiController]
    [Route("api/message")]
    public class MessageController : Controller
    {
        protected readonly IHubContext<GatewayHub> _gatewayHub;
        public MessageController([NotNull] IHubContext<GatewayHub> messageHub)
        {
            _gatewayHub = messageHub;
        }

        [HttpPost]
        public async Task<IActionResult> Create(MessagePost messagePost)
        {
            await _gatewayHub.Clients.All.SendAsync("sendToReact", $"The message \"{messagePost.Message}\" has been received.");

            return Ok();
        }

    }
    public class MessagePost
    {
        public virtual string? Message { get; set; }
    }
}
