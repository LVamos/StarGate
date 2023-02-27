using AutoMapper;

using StarGate.Business.Interfaces;
using StarGate.Business.Models;
using StarGate.Data.Interfaces;
using StarGate.Data.Models;

namespace StarGate.Business.Managers;

/// <summary>
///  A planet manager.
/// </summary>
public class PlanetManager : IPlanetManager
{
	/// <summary>
	/// Finds a planet by its code.
	/// </summary>
	/// <param name="code">A code string identifying the planet</param>
	/// <returns>DTO object of the wanted planet or null</returns>
	public PlanetDto? GetPlanetByCode(string code)
	{
		Planet? planet = _planetRepository.FindByCode(code);

		if (planet is null)
			return null;

		return _mapper.Map<PlanetDto>(planet);
	}

	/// <summary>
	/// Deletes a planet.
	/// </summary>
	/// <param name="code">A short string identifying the planet</param>
	/// <returns>True if the planet was deleted</returns>
	public bool DeletePlanet(string code) => _planetRepository.Delete(code);

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
	public PlanetDto? AddPlanet(string code, string name, string teamCode, bool explored, PlanetSafety safety, string symbol1, string symbol2, string symbol3, string symbol4, string symbol5, string symbol6, string symbol7)
	{
		// Try to save address.
		AddressDto? address = _addressManager.AddAddress(symbol1, symbol2, symbol3, symbol4, symbol5, symbol6, symbol7);
		if (address is null)
			return null;

		// Get team.
		TeamDto? team = null;
		if (explored)
		{
			team = _teamManager.GetTeamByCode(teamCode);
			if (team is null)
				return null;
		}

		// Store the planet.
		PlanetDto planet = new()
		{
			Code = code,
			Name = name,
			TeamId = team is null ? null : team.Id,
			Explored = explored,
			Safety = safety,
			AddressId = address.Id
		};

		return AddPlanet(planet);
	}

	/// <summary>
	/// Updates a planet.
	/// </summary>
	/// <param name="code">A short string identifying the planet</param>
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
	public PlanetDto? UpdatePlanet(string code, string name, string teamCode, bool explored, PlanetSafety safety, string symbol1, string symbol2, string symbol3, string symbol4, string symbol5, string symbol6, string symbol7)
	{
		// Try to find address in database. If it doesn't exist, create it.
		AddressDto? address = _addressManager.GetAddress(symbol1, symbol2, symbol3, symbol4, symbol5, symbol6, symbol7);

		if (address is null)
		{
			// Create it.
			address = _addressManager.AddAddress(symbol1, symbol2, symbol3, symbol4, symbol5, symbol6, symbol7);
			if (address is null)
				return null;
		}

		// Get team if the planet has been explored.
		TeamDto? team = null;
		if (explored)
		{
			team = _teamManager.GetTeamByCode(teamCode);
			if (team is null)
				return null;
		}

		// Get planet.
		PlanetDto? currentPlanet = GetPlanetByCode(code);
		if (currentPlanet is null)
			return null;

		// Update planet.
		PlanetDto? newPlanet = new PlanetDto()
		{
			Id = currentPlanet.Id,
			Code = code,
			Name = name,
			TeamId = team is null ? null : team.Id,
			Explored = explored,
			Safety = safety,
			AddressId = address.Id
		};

		Planet planet = _mapper.Map<Planet>(newPlanet);
		Planet? updatedPlanet = _planetRepository.Update(planet);

		if (updatedPlanet is null)
			return null;

		return _mapper.Map<PlanetDto>(updatedPlanet);
	}

	/// <summary>
	///  Adds a planet.
	/// </summary>
	/// <param name="planetDto">The planet to be added as an DTO object</param>
	/// <returns>Newly added planet as an DTO object</returns>
	public PlanetDto AddPlanet(PlanetDto planetDto)
	{
		Planet planet = _mapper.Map<Planet>(planetDto);
		Planet newPlanet = _planetRepository.Insert(planet);

		return _mapper.Map<PlanetDto>(newPlanet);
	}

	/// <summary>
	/// Deletes a planet.
	/// </summary>
	/// <param name="id">Id of the planet to be deleted</param>
	/// <returns>True if the specified planet was deleted</returns>
	public bool DeletePlanet(int id)
	{
		bool found = _planetRepository.ExistsWithId(id);

		if (found)
			_planetRepository.Delete(id);

		return found;
	}

	/// <summary>
	///  Gets a planet.
	/// </summary>
	/// <param name="id">Id of the requested planet</param>
	/// <returns>A data transformation object</returns>
	public PlanetDto? GetPlanet(int id)
	{
		Planet? planet = _planetRepository.FindById(id);

		if (planet is null)
			return null;

		return _mapper.Map<PlanetDto>(planet);
	}

	/// <summary>
	///  The planet repository.
	/// </summary>
	private readonly IPlanetRepository _planetRepository;

	/// <summary>
	/// The address manager
	/// </summary>
	private readonly IAddressManager _addressManager;

	/// <summary>
	/// The team manager
	/// </summary>
	private readonly ITeamManager _teamManager;

	/// <summary>
	/// The mapper
	/// </summary>
	private readonly IMapper _mapper;

	/// <summary>
	///  Returns all planets.
	/// </summary>
	/// <returns>A list of planets</returns>
	public IList<PlanetDto> GetAllPlanets()
	{
		IList<Planet> planets = _planetRepository.GetAll();
		return _mapper.Map<IList<PlanetDto>>(planets);
	}

	/// <summary>
	/// Updates a planet.
	/// </summary>
	/// <param name="code">A short string identifying the planet</param>
	/// <param name="planet">A DTO object representing target modification of the planet</param>
	/// <returns>A DTO object of the updated planet or null</returns>
	public PlanetDto? UpdatePlanet(string code, PlanetDto planet)
	{
		PlanetDto updatedPlanet = GetPlanetByCode(code);
		if (updatedPlanet is null)
			return null;

		return UpdatePlanet(updatedPlanet.Code, updatedPlanet);
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="planetRepository">The planet repository</param>
	/// <param name="mapper">The mapper</param>
	public PlanetManager(IPlanetRepository planetRepository, IAddressManager addressManager, ITeamManager teamManager, IMapper mapper)
	{
		_planetRepository = planetRepository;
		_addressManager = addressManager;
		_teamManager = teamManager;
		_mapper = mapper;
	}
}