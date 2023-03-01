using Microsoft.AspNetCore.SignalR.Client;

// Establish SignalR connection
HubConnection connection = new HubConnectionBuilder()
	.WithUrl("https://localhost:7230/RequestQueueHub")
	.Build();

connection.Closed += async (error) =>
{
	Console.WriteLine(error.Message);
	await Task.Delay(15000);
	Environment.Exit(0);
};

connection.On<string, string>(
	"ReceiveMessage", (string title, string message) => Console.WriteLine($"{title}: {message}"));
await connection.StartAsync();

while (true)
{
	await Task.Delay(10);
	if (Console.ReadKey().Key == ConsoleKey.Enter)
	{
		connection.StopAsync();
		Environment.Exit(0);
	}
}
