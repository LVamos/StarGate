using Microsoft.AspNetCore.Mvc;

using StarGate.Business.Interfaces;
using StarGate.Business.Models;
using StarGate.Data;
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
	/// <param name="id">Id of the planet to be updated</param>
	/// <param name="planet">DTO object with modified planet</param>
	/// <returns>IActionResult</returns>
	[HttpPut("planets/{id}")]
	public IActionResult EditPlanet(uint id, [FromBody] PlanetDto planet)
	{
		PlanetDto? updatedPlanet = _planetManager.UpdatePlanet(id, planet);

		if (updatedPlanet is null)
			return NotFound();

		return Ok(updatedPlanet);
	}

	/// <summary>
	///  Adds a planet.
	/// </summary>
	/// <param name="name">Name of the planet</param>
	/// <param name="teamId">Id of a team that has explored the planet</param>
	/// <param name="explored"><Whether the lanet has been explored/param>
	/// <param name="safety">Safety clasification</param>
	/// <param name="symbol1">1st symbol of address of the planet</param>
	/// <param name="symbol2">2nd  symbol of address of the planet</param>
	/// <param name="symbol3">3rd  symbol of address of the planet</param>
	/// <param name="symbol4">4th  symbol of address of the planet</param>
	/// <param name="symbol5">5th  symbol of address of the planet</param>
	/// <param name="symbol6">6th  symbol of address of the planet</param>
	/// <param name="symbol7">7th  symbol of address of the planet</param>
	/// <returns>IActionResult</returns>
	//[HttpPost("planets")]
	//public IActionResult AddPlanet(string name, uint teamId, bool explored, PlanetSafety safety, uint symbol1, uint symbol2, uint symbol3, uint symbol4, uint symbol5, uint symbol6, uint symbol7)
	//{
	[HttpGet("test")]
	public IActionResult Index()
	{
		string name = "Makovec"; uint teamId = 3; bool explored = true; PlanetSafety safety = default; uint symbol1 = 3, symbol2 = 3, symbol3 = 3, symbol4 = 3, symbol5 = 3, symbol6 = 3, symbol7 = 3;

		// Store the address.
		AddressDto? addressDto = new AddressDto
		{
			Symbol1 = _symbolManager.GetSymbol(symbol1),
			Symbol2 = _symbolManager.GetSymbol(symbol2),
			Symbol3 = _symbolManager.GetSymbol(symbol3),
			Symbol4 = _symbolManager.GetSymbol(symbol4),
			Symbol5 = _symbolManager.GetSymbol(symbol5),
			Symbol6 = _symbolManager.GetSymbol(symbol6),
			Symbol7 = _symbolManager.GetSymbol(symbol7)
		};

		AddressDto? newAddress = _addressManager.AddAddress(addressDto);
		if (newAddress is null)
			return Problem(statusCode: 500, detail: "Address could not be stored");

		// Store the planet.
		PlanetDto planet = new PlanetDto
		{
			Id = default,
			Name = name,
			Explored = explored,
			Safety = safety,
			Team = _teamManager.GetTeam(teamId),
			Address = addressDto
		};

		PlanetDto? newPlanet = _planetManager.AddPlanet(planet);

		return CreatedAtAction(nameof(GetPlanet), new
		{
			Id = newPlanet.Id
		}, newPlanet);
	}

	/// <summary>
	///  Deletes a planet.
	/// </summary>
	/// <param name="id">Id of the planet to be deleted</param>
	/// <returns>IActionResult</returns>
	[HttpDelete("planets/{id}")]
	public IActionResult DeletePlanet(uint id) => _planetManager.DeletePlanet(id) ? Ok() : NotFound();

	/// <summary>
	///  Gets a planet.
	/// </summary>
	/// <param name="id"></param>
	/// <returns>IActionResult</returns>
	[HttpGet("planets/{id}")]
	public IActionResult GetPlanet(uint id)
	{
		PlanetDto? planet = _planetManager.GetPlanet(id);

		return planet is null ? NotFound() : Ok(planet);
	}

	/// <summary>
	///  Gets all planets.
	/// </summary>
	/// <returns>ienumeration of planets</returns>
	[HttpGet("planets")]
	public IEnumerable<PlanetDto> GetPlanets() => _planetManager.GetAllPlanets();

	/// <summary>
	/// Current database context
	/// </summary>
	private readonly StarGateDbContext _context;

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
	public PlanetsController(StarGateDbContext context, IPlanetManager planetManager, IAddressManager addressManager, ISymbolManager symbolManager, ITeamManager teamManager)
	{
		_context = context;
		_planetManager = planetManager;
		_addressManager = addressManager;
		_teamManager = teamManager;
		_symbolManager = symbolManager;
	}
}