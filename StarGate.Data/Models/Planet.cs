using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarGate.Data.Models;

/// <summary>
/// Describes the security classification of a planet.
/// </summary>
public enum PlanetSafety
{
	Neutral,
	Friendly,
	Unfriendly
}

/// <summary>
/// Describes the Planet entity.
/// </summary>
public class Planet
{
	/// <summary>
	/// Primary key identifying the planet
	/// </summary>
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Key()]
	public uint Id { get; set; }

	/// <summary>
	/// Specifies if the planet has already been explored by a Stargate team.
	/// </summary>
	[Required]
	public bool Explored { get; set; }

	/// <summary>
	/// A team that has explored the planet.
	/// </summary>
	public virtual Team Team { get; set; }

	/// <summary>
	/// Specifies the security classification of a planet.
	/// </summary>
	public PlanetSafety Safety { get; set; } = PlanetSafety.Neutral;

	/// <summary>
	/// Name of the planet.
	/// </summary>
	[StringLength(30)]
	public string Name { get; set; } = "";

	/// <summary>
	/// Address of a star gate on the planet.
	/// </summary>
	[Required]
	public virtual Address Address { get; set; }
}
