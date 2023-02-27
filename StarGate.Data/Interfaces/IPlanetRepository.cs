using StarGate.Data.Models;

namespace StarGate.Data.Interfaces;

/// <summary>
/// An interface for a repository of planets
/// </summary>
public interface IPlanetRepository : IBaseRepository<Planet>
{
	/// <summary>
	/// Deletes a planet.
	/// </summary>
	/// <param name="code">A short string identifying the planet</param>
	/// <returns>True if the planet was deleted</returns>
	bool Delete(string code);

	/// <summary>
	/// Finds a planet by its code.
	/// </summary>
	/// <param name="code">A code string identifying the planet</param>
	/// <returns>DTO object of the wanted planet or null</returns>
	Planet? FindByCode(string code);
}
