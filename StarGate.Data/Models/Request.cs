using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
[Index(nameof(Request.Code), IsUnique = true)]
public class Request
{
	/// <summary>
	/// A unique identifier of a request.
	/// </summary>
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Key()]
	public int Id { get; set; }

	/// <summary>
	/// Specifies what stargate request should be made.
	/// </summary>
	[Required]
	public RequestType Type { get; set; }

	/// <summary>
	/// A short string identifying the request.
	/// </summary>
	[Required]
	[StringLength(10)]
	public string Code { get; set; }

	/// <summary>
	/// A foreign key referencing to a planet.
	/// </summary>
	public int PlanetId { get; set; }

	/// <summary>
	/// A planet to be explored.
	/// </summary>
	public virtual Planet Planet { get; set; }
}
