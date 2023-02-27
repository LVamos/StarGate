using Microsoft.AspNetCore.Mvc;

using StarGate.Business.Interfaces;
using StarGate.Business.Models;
using StarGate.Data.Models;

namespace StarGate.Controllers;

/// <summary>
///  A planets controller.
/// </summary>
[Route("api")]
[ApiController]
public class PlanetsController : ControllerBase
{
	/// <summary>
	/// Updates a planet.
	/// </summary>
	/// <param name="code">A short string identifying the planet</param>
	/// <param name="planet">DTO object with modified planet</param>
	/// <returns>IActionResult</returns>
	[HttpPut("planets")]
	public IActionResult EditPlanet(string code, string name, string teamCode, bool explored, PlanetSafety safety, string symbol1, string symbol2, string symbol3, string symbol4, string symbol5, string symbol6, string symbol7)
	{
		PlanetDto? updatedPlanet = _planetManager.UpdatePlanet(code, name, teamCode, explored, safety, symbol1, symbol2, symbol3, symbol4, symbol5, symbol6, symbol7);

		if (updatedPlanet is null)
			return Problem(title: "Error", detail: "The planet could not be updated.", statusCode: 500);

		return Ok(updatedPlanet);
	}

	/// <summary>
	///  Adds a planet.
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
	/// <returns>IActionResult</returns>
	[HttpPost("planets")]
	public IActionResult AddPlanet(string planetCode, string planetName, string teamCode, bool explored, PlanetSafety safety, string symbol1, string symbol2, string symbol3, string symbol4, string symbol5, string symbol6, string symbol7)
	{
		PlanetDto? planet = _planetManager.AddPlanet(planetCode, planetName, teamCode, explored, safety, symbol1, symbol2, symbol3, symbol4, symbol5, symbol6, symbol7);

		if (planet is null)
			return Problem(title: "Error", detail: "Planet could not be added", statusCode: 500);

		return CreatedAtAction(nameof(GetPlanet), new
		{
			Id = planet.Id
		}, planet);
	}

	/// <summary>
	///  Deletes a planet.
	/// </summary>
	/// <param name="code">A short string identifying the planet</param>
	/// <returns>IActionResult</returns>
	[HttpDelete("planets")]
	public IActionResult DeletePlanet(string code)
	{
		if (!_planetManager.DeletePlanet(code))
			return Problem(title: "Error", detail: "The planet could not be deleted properly.", statusCode: 500);

		return Ok();
	}

	/// <summary>
	///  Gets a planet.
	/// </summary>
	/// <param name="code">A short string identifying the planet</param>
	/// <returns>IActionResult</returns>
	[HttpGet("planets/{code}")]
	public IActionResult GetPlanet(string code)
	{
		PlanetDto? planet = _planetManager.GetPlanetByCode(code);

		return planet is null ? NotFound() : Ok(planet);
	}

	/// <summary>
	///  Gets all planets.
	/// </summary>
	/// <returns>ienumeration of planets</returns>
	[HttpGet("planets")]
	public IEnumerable<PlanetDto> GetPlanets() => _planetManager.GetAllPlanets();

	/// <summary>
	///  A planet manager.
	/// </summary>
	private readonly IPlanetManager _planetManager;

	/// <summary>
	/// An address manager
	/// </summary>
	private readonly IAddressManager _addressManager;

	/// <summary>
	/// A team manager
	/// </summary>
	private readonly ITeamManager _teamManager;

	/// <summary>
	///  A symbol manager
	/// </summary>
	private readonly ISymbolManager _symbolManager;

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="planetManager">A planet manager</param>
	public PlanetsController(IPlanetManager planetManager, IAddressManager addressManager, ISymbolManager symbolManager, ITeamManager teamManager)
	{
		_planetManager = planetManager;
		_addressManager = addressManager;
		_teamManager = teamManager;
		_symbolManager = symbolManager;
	}
}