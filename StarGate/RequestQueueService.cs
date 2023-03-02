using Microsoft.AspNetCore.SignalR;

using StarGate.Business.Interfaces;
using StarGate.Business.Models;
using StarGate.Data.Models;
using StarGate.Hubs;

namespace StarGate;

/// <summary>
/// The request queue runing on background.
/// </summary>
public class RequestQueueService : BackgroundService
{
	/// <summary>
	/// Takes the most recent request from database and sends it to the clients.
	/// </summary>
	/// <param name="state"></param>
	private void HandleRequest(object? state)
	{
		// Require the request manager via dependency injection.
		using var scope = _serviceScopeFactory.CreateScope();
		IRequestManager requestManager = scope.ServiceProvider.GetService<IRequestManager>();

		// Take the most recent request from database.
		IEnumerable<RequestDto> records = requestManager.GetAllRequests().AsEnumerable<RequestDto>();
		if (!records.Any())
			return;

		int min = records.Min(r => r.Id);
		RequestDto request = records.FirstOrDefault(r => r.Id == min);
		requestManager.DeleteRequest(request.Code);

		// Send message to SignalR clients.
		if (request.Type == RequestType.Diagnostics)
		{
			SendMessage("Request", "DIAG");
			return;
		}

		// Cast Open star gate request and schedule casting symbols of the target address in 2 second interval.
		SendMessage("Request", "OPEN");
		_address.Enqueue(request.Planet.Address.Symbol1.Code);
		_address.Enqueue(request.Planet.Address.Symbol2.Code);
		_address.Enqueue(request.Planet.Address.Symbol3.Code);
		_address.Enqueue(request.Planet.Address.Symbol4.Code);
		_address.Enqueue(request.Planet.Address.Symbol5.Code);
		_address.Enqueue(request.Planet.Address.Symbol6.Code);
		_address.Enqueue(request.Planet.Address.Symbol7.Code);
	}

	/// <summary>
	/// Sends a message to all clients.
	/// </summary>
	/// <param name="title">Tittle of the message</param>
	/// <param name="message">The content</param>
	private void SendMessage(string title, string message) => _hubContext.Clients.All.SendAsync("ReceiveMessage", title, message);

	/// <summary>
	/// takes one symbol from the address queue and sends it to clients.
	/// </summary>
	/// <param name="state">state of the timer that launches this method.</param>
	private void SendSymbol(object? state)
	{
		if (_address.Count == 0)
			return;

		string symbol = _address.Dequeue();
		SendMessage("Symbol", symbol);
	}

	/// <summary>
	/// A timer for sending address symbols to clients.
	/// </summary>
	Timer _addressTimer;

	/// <summary>
	/// Contains the current address to be casted.
	/// </summary>
	Queue<string> _address = new();

	/// <summary>
	/// 
	/// </summary>
	private readonly object serviceScopeFactory;

	/// <summary>
	/// Allows to create a scope for a service.
	/// </summary>
	private readonly IServiceScopeFactory _serviceScopeFactory;

	/// <summary>
	/// The SignalR hub context.
	/// </summary>
	private readonly IHubContext<RequestQueueHub> _hubContext;

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="serviceScopeFactory">Allows creating scopes manually</param>
	/// <param name="hubContext">The SignalR context</param>
	public RequestQueueService(IServiceScopeFactory serviceScopeFactory, IHubContext<RequestQueueHub> hubContext)
	{
		_serviceScopeFactory = serviceScopeFactory;
		_hubContext = hubContext;
	}

	/// <summary>
	/// A timer for sending requests to the clients.
	/// </summary>
	private Timer _requestTimer;

	/// <summary>
	/// Starts the background service.
	/// </summary>
	/// <param name="stoppingToken">The stopping token</param>
	/// <returns>Task</returns>
	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		_addressTimer = new Timer(SendSymbol, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));
		_requestTimer = new Timer(HandleRequest, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));

		while (!stoppingToken.IsCancellationRequested)
		{
			await Task.Delay(5, stoppingToken);
		}
	}
}