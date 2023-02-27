using StarGate.Data.Models;

namespace StarGate.Business.Models;

/// <summary>
/// A data transfer object for a request
/// </summary>
public class RequestDto
{
	/// <summary>
	/// A unique identifier of a request.
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	/// A short string identifying the request.
	/// </summary>
	public string Code { get; set; }

	/// <summary>
	/// Specifies what stargate request should be made.
	/// </summary>
	public RequestType Type { get; set; }

	/// <summary>
	/// A planet to be explored.
	/// </summary>
	public PlanetDto Planet { get; set; }
}
