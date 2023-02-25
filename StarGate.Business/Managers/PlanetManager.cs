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
	/// Updates a planet.
	/// </summary>
	/// <param name="id">Id of the planet to be updated</param>
	/// <param name="planetDto">DTO object with modified planet</param>
	/// <returns>The updated planet or null if the specified planet wasn't found</returns>
	public PlanetDto? UpdatePlanet(uint id, PlanetDto planetDto)
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
	public bool DeletePlanet(uint id)
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
	public PlanetDto? GetPlanet(uint id)
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
	public PlanetManager(IPlanetRepository planetRepository, IMapper mapper)
	{
		_planetRepository = planetRepository;
		_mapper = mapper;
	}
}