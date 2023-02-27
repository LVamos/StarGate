using StarGate.Data.Models;

using System.ComponentModel.DataAnnotations;

namespace StarGate.Business.Models;

/// <summary>
///  A DTO for a planet.
/// </summary>
public class PlanetDto
{
	/// <summary>
	/// Id of the planet
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	/// Specifies if the planet has already been explored by a Stargate team.
	/// </summary>
	public bool Explored { get; set; }

	public int? TeamId { get; set; }

	/// <summary>
	/// A team that has explored the planet.
	/// </summary>
	public TeamDto Team { get; set; }

	/// <summary>
	/// Specifies the security classification of a planet.
	/// </summary>
	public PlanetSafety Safety { get; set; } = PlanetSafety.Neutral;

	/// <summary>	/// <summary>
	/// Unique code of the planet.
	/// </summary>
	[StringLength(10)]
	public string Code { get; set; } = "";

	/// Name of the planet.
	/// </summary>
	public string Name { get; set; }

	public int AddressId { get; set; }

	/// <summary>
	/// Address of the planet.
	/// </summary>
	public AddressDto Address { get; set; }
}
