using StarGate.Business.Models;

namespace StarGate.Business.Interfaces;

/// <summary>
///  A planet manager interface.
/// </summary>
public interface IPlanetManager
{
	/// <summary>
	///  Adds a planet.
	/// </summary>
	/// <param name="planetDto">The planet to be added as an DTO object</param>
	/// <returns>Newly added planet as an DTO object</returns>
	PlanetDto AddPlanet(PlanetDto planetDto);

	/// <summary>
	/// Deletes a planet.
	/// </summary>
	/// <param name="id">Id of the planet to be deleted</param>
	/// <returns>True if the specified planet was deleted</returns>
	bool DeletePlanet(uint id);

	/// <summary>
	///  Returns all planets.
	/// </summary>
	/// <returns>A list of planets</returns>
	IList<PlanetDto> GetAllPlanets();

	/// <summary>
	///  Gets a planet.
	/// </summary>
	/// <param name="id">Id of the requested planet</param>
	/// <returns>A data transformation object</returns>
	PlanetDto? GetPlanet(uint id);


	/// <summary>
	/// Updates a planet.
	/// </summary>
	/// <param name="id">Id of the planet to be updated</param>
	/// <param name="planetDto">DTO object with modified planet</param>
	/// <returns>The updated planet or null if the specified planet wasn't found</returns>
	PlanetDto? UpdatePlanet(uint id, PlanetDto planetDto);
}