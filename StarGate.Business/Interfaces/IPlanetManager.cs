using StarGate.Business.Models;
using StarGate.Data.Models;

namespace StarGate.Business.Interfaces;

/// <summary>
///  A planet manager interface.
/// </summary>
public interface IPlanetManager
{
	/// <summary>
	/// Adds a planet.
	/// </summary>
	/// <param name="planetCode">A short string identifying the planet</param>
	/// <param name="name">Name of the planet</param>
	/// <param name="teamCode">Id of a team that has explored the planet</param>
	/// <param name="explored"><Whether the lanet has been explored/param>
	/// <param name="safety">Safety clasification</param>
	/// <param name="symbol1">1st symbol of address of the planet</param>
	/// <param name="symbol2">2nd  symbol of address of the planet</param>
	/// <param name="symbol3">3rd  symbol of address of the planet</param>
	/// <param name="symbzol4">4th  symbol of address of the planet</param>
	/// <param name="symbol5">5th  symbol of address of the planet</param>
	/// <param name="symbol6">6th  symbol of address of the planet</param>
	/// <param name="symbol7">7th  symbol of address of the planet</param>
	/// <returns>An DTO object representing the planet</returns>
	PlanetDto? AddPlanet(string code, string name, string teamCode, bool explored, PlanetSafety safety, string symbol1, string symbol2, string symbol3, string symbol4, string symbol5, string symbol6, string symbol7);

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
	bool DeletePlanet(int id);

	/// <summary>
	/// Deletes a planet.
	/// </summary>
	/// <param name="code">A short string identifying the planet</param>
	/// <returns>True if the planet was deleted</returns>
	bool DeletePlanet(string code);

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
	PlanetDto? GetPlanet(int id);
	PlanetDto? GetPlanetByCode(string code);


	/// <summary>
	/// Updates a planet.
	/// </summary>
	/// <param name="planetCode">A short string identifying the planet</param>
	/// <param name="name">Name of the planet</param>
	/// <param name="teamCode">Id of a team that has explored the planet</param>
	/// <param name="explored"><Whether the lanet has been explored/param>
	/// <param name="safety">Safety clasification</param>
	/// <param name="symbol1">1st symbol of address of the planet</param>
	/// <param name="symbol2">2nd  symbol of address of the planet</param>
	/// <param name="symbol3">3rd  symbol of address of the planet</param>
	/// <param name="symbzol4">4th  symbol of address of the planet</param>
	/// <param name="symbol5">5th  symbol of address of the planet</param>
	/// <param name="symbol6">6th  symbol of address of the planet</param>
	/// <param name="symbol7">7th  symbol of address of the planet</param>
	/// <returns>The updated planet or null if the specified planet wasn't found</returns>
	PlanetDto? UpdatePlanet(string code, string name, string teamCode, bool explored, PlanetSafety safety, string symbol1, string symbol2, string symbol3, string symbol4, string symbol5, string symbol6, string symbol7);

	/// <summary>
	/// Updates a planet.
	/// </summary>
	/// <param name="code">A short string identifying the planet</param>
	/// <param name="planet">A DTO object representing target modification of the planet</param>
	/// <returns>A DTO object of the updated planet or null</returns>
	PlanetDto? UpdatePlanet(string code, PlanetDto planet);
}