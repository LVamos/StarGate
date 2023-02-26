namespace StarGate.Business.Models;

/// <summary>
/// A data transfer object for a team
/// </summary>
public class TeamDto
{
	/// <summary>
	/// Id of the team
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	/// Unique code of the team
	/// </summary>
	public string Code { get; set; } = "";

	/// <summary>
	/// Name of the team
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// Number of team members
	/// </summary>
	public int Members { get; set; }
}
