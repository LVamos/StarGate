using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarGate.Data.Models;

/// <summary>
/// A star gate team
/// </summary>
[Index(nameof(Team.Name), IsUnique = true)]
public class Team
{
	/// <summary>
	/// Primary key identifying the team
	/// </summary>
	[DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
	public uint Id { get; set; }

	/// <summary>
	/// Name of the team
	/// </summary>
	[Required]
	[StringLength(30, MinimumLength = 1)]
	public string Name { get; set; } = "";

	/// <summary>
	/// Number of team members
	/// </summary>
	[Required]
	[Range(1, uint.MaxValue)]
	public uint Members { get; set; }
}
