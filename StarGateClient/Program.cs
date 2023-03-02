using Microsoft.AspNetCore.SignalR.Client;

// Displays a prompt and terminates the program.
void Terminate(string message = "")
{
	Console.WriteLine(message);
	Console.WriteLine("Press enter to terminate.");
	Console.ReadLine();
	Environment.Exit(0);
}

// A callback method for receiving messages from the server.
static void ReceiveMessage(string title, string message) => Console.WriteLine($"{title}: {message}");

// Establish SignalR connection
HubConnection connection = new HubConnectionBuilder()
	.WithUrl("https://localhost:7230/RequestQueueHub")
	.Build();

// Set up callback.
connection.Closed += async (error) => Terminate(error.Message);

connection.On<string, string>("ReceiveMessage", ReceiveMessage);

Console.WriteLine("Establishing connection");
try
{
	await connection.StartAsync();
}
catch
{
	Terminate("Unable to establish connection to the server.");
}

Console.WriteLine("Listening to the server. Press any key to stop.");
while (true)
{
	await Task.Delay(10);

	if (Console.ReadKey().Key == ConsoleKey.Enter)
	{
		await connection.StopAsync();
		Terminate("Connection ended.");
		break;
	}
}
