using Microsoft.AspNetCore.SignalR;

namespace StarGate.Hubs;

/// <summary>
/// Hub for sending messages to all clients
/// </summary>
public class RequestQueueHub : Hub
{
	/// <summary>
	/// Sends message to all clients.
	/// </summary>
	/// <param name="title">Title of the message</param>
	/// <param name="message">The message content</param>
	/// <returns>A Task object</returns>
	public async Task SendMessage(string title, string message)
	{
		await Clients.All.SendAsync("ReceiveMessage", title, message);
	}
}
