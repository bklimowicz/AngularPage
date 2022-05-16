using Microsoft.AspNetCore.SignalR;

namespace Libraries.SignalR.Hubs
{
	public class GatewayHub : Hub
	{
		public GatewayHub()
		{

		}

		public async Task Login(object user)
		{
			await Clients.All.SendAsync("loginUserAction_ServerResponse", "ACK");
		}
	}
}

