using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace StarGate.Data.Models;

/// <summary>
/// Describes possible star gate requests.
/// </summary>
public enum RequestType
{
	Diagnostics,
	Open
}

/// <summary>
/// A queue storing star gate requests.
/// </summary>
[Keyless]
public class Request
{
	/// <summary>
	/// Specifies what stargate request should be made.
	/// </summary>
	[Required]
	public RequestType Type { get; set; }

	public int PlanetId { get; set; }

	/// <summary>
	/// A planet to be explored.
	/// </summary>
	public virtual Planet Planet { get; set; }
}
