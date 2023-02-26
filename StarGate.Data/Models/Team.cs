using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarGate.Data.Models;

/// <summary>
/// A star gate team
/// </summary>
[Index(nameof(Team.Name), IsUnique = true)]
[Index(nameof(Team.Code), IsUnique = true)]
public class Team
{
	/// <summary>
	/// Primary key identifying the team
	/// </summary>
	[DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
	public int Id { get; set; }

	/// <summary>
	/// Unique code of the team
	/// </summary>
	public string Code { get; set; } = "";

	/// <summary>
	/// Name of the team
	/// </summary>
	[Required]
	[StringLength(30)]
	public string Name { get; set; } = "";

	/// <summary>
	/// Number of team members
	/// </summary>
	[Required]
	[Range(1, int.MaxValue)]
	public int Members { get; set; }
}
