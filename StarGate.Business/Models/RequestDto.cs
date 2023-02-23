using StarGate.Data.Models;

namespace StarGate.Business.Models;

/// <summary>
/// A data transfer object for an request
/// </summary>
public class RequestDto
{
	/// <summary>
	/// Specifies what stargate request should be made.
	/// </summary>
	public RequestType Type { get; set; }

	/// <summary>
	/// A planet to be explored.
	/// </summary>
	public PlanetDto Planet { get; set; }
}
