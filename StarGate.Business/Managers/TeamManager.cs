using AutoMapper;

using StarGate.Business.Interfaces;
using StarGate.Business.Models;
using StarGate.Data.Interfaces;
using StarGate.Data.Models;

namespace StarGate.Business.Managers;

/// <summary>
///  A team manager.
/// </summary>
public class TeamManager : ITeamManager
{
	/// <summary>
	/// Finds a team by its code.
	/// </summary>
	/// <param name="code">A code string identifying the team</param>
	/// <returns>DTO object of the wanted team or null</returns>
	public TeamDto? GetTeamByCode(string code)
	{
		Team? team = _teamRepository.FindByCode(code);

		if (team is null)
			return null;

		return _mapper.Map<TeamDto>(team);
	}


	/// <summary>
	/// Updates a team.
	/// </summary>
	/// <param name="id">Id of the team to be updated</param>
	/// <param name="teamDto">DTO object with modified team</param>
	/// <returns>The updated team or null if the specified team wasn't found</returns>
	public TeamDto? UpdateTeam(int id, TeamDto teamDto)
	{
		if (!_teamRepository.ExistsWithId(id))
			return null;

		Team team = _mapper.Map<Team>(teamDto);
		team.Id = id;
		Team updatedTeam = _teamRepository.Update(team);

		return _mapper.Map<TeamDto>(updatedTeam);
	}

	/// <summary>
	///  Adds a team.
	/// </summary>
	/// <param name="teamDto">The team to be added as an DTO object</param>
	/// <returns>Newly added team as an DTO object</returns>
	public TeamDto AddTeam(TeamDto teamDto)
	{
		Team team = _mapper.Map<Team>(teamDto);
		team.Id = default; // Set to zero so that the primary key can be generated.
		Team newTeam = _teamRepository.Insert(team);

		return _mapper.Map<TeamDto>(newTeam);
	}

	/// <summary>
	/// Deletes a team.
	/// </summary>
	/// <param name="id">Id of the team to be deleted</param>
	/// <returns>True if the specified team was deleted</returns>
	public bool DeleteTeam(int id)
	{
		bool found = _teamRepository.ExistsWithId(id);

		if (found)
			_teamRepository.Delete(id);

		return found;
	}

	/// <summary>
	///  Gets a team.
	/// </summary>
	/// <param name="id">Id of the requested team</param>
	/// <returns>A data transformation object</returns>
	public TeamDto? GetTeam(int id)
	{
		Team? team = _teamRepository.FindById(id);

		if (team is null)
			return null;

		return _mapper.Map<TeamDto>(team);
	}

	/// <summary>
	///  The team repository.
	/// </summary>
	private readonly ITeamRepository _teamRepository;

	/// <summary>
	/// The mapper
	/// </summary>
	private readonly IMapper _mapper;

	/// <summary>
	///  Returns all teams.
	/// </summary>
	/// <returns>A list of teams</returns>
	public IList<TeamDto> GetAllTeams()
	{
		IList<Team> teams = _teamRepository.GetAll();
		return _mapper.Map<IList<TeamDto>>(teams);
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="teamRepository">The team repository</param>
	/// <param name="mapper">The mapper</param>
	public TeamManager(ITeamRepository teamRepository, IMapper mapper)
	{
		_teamRepository = teamRepository;
		_mapper = mapper;
	}
}