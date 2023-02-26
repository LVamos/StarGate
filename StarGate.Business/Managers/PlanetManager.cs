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
		TeamDto? team = _teamManager.GetTeamByCode(teamCode);
		if (team is null)
			return null;

		// Store the planet.
		PlanetDto planet = new()
		{
			Code = code,
			Name = name,
			TeamId = team.Id,
			Explored = explored,
			Safety = safety,
			AddressId = address.Id
		};

		return AddPlanet(planet);
	}

	/// <summary>
	/// Updates a planet.
	/// </summary>
	/// <param name="id">Id of the planet to be updated</param>
	/// <param name="planetDto">DTO object with modified planet</param>
	/// <returns>The updated planet or null if the specified planet wasn't found</returns>
	public PlanetDto? UpdatePlanet(int id, PlanetDto planetDto)
	{
		if (!_planetRepository.ExistsWithId(id))
			return null;

		Planet planet = _mapper.Map<Planet>(planetDto);
		planet.Id = id;
		Planet updatedPlanet = _planetRepository.Update(planet);

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