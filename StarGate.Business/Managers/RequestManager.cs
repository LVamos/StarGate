using AutoMapper;

using StarGate.Business.Interfaces;
using StarGate.Business.Models;
using StarGate.Data.Interfaces;
using StarGate.Data.Models;

namespace StarGate.Business.Managers;

/// <summary>
///  A request manager.
/// </summary>
public class RequestManager : IRequestManager
{
	/// <summary>
	/// Updates a request.
	/// </summary>
	/// <param name="id">Id of the request to be updated</param>
	/// <param name="requestDto">DTO object with modified request</param>
	/// <returns>The updated request as DTO or null if the specified request wasn't found</returns>
	public RequestDto? UpdateRequest(int id, RequestDto requestDto)
	{
		Request request = _mapper.Map<Request>(requestDto);
		Request updatedRequest = _requestRepository.Update(request);

		return _mapper.Map<RequestDto>(updatedRequest);
	}

	/// <summary>
	/// Updates a request.
	/// </summary>
	/// <param name="code">A short string identifying the request to be updated</param>
	/// <param name="type">Type of the request</param>
	/// <param name="planetCode">Code of the target planet </param>
	/// <returns>The updated request as a DTO or null if the specified request wasn't found</returns>
	public RequestDto? UpdateRequest(string code, RequestType type, string planetCode = "")
	{
		// Find the request to modify.
		RequestDto? requestDto = GetRequestByCode(code);
		if (requestDto is null)
			return null;

		// Make validation.
		if (type != RequestType.Open && !string.IsNullOrEmpty(planetCode))
			return null;

		// If the request is a diagnostics request, the planet id should be null.
		if (type == RequestType.Diagnostics)
			requestDto.PlanetId = null;
		else
		{
			// Check if the planet exists.
			PlanetDto? planet = _planetManager.GetPlanetByCode(planetCode);
			if (planet is null)
				return null;
			requestDto.PlanetId = planet.Id;
		}

		requestDto.Type = type;
		return UpdateRequest(requestDto.Id, requestDto);
	}


	/// <summary>
	/// Deletes a request.
	/// </summary>
	/// <param name="code">A short string identifying the request</param>
	/// <returns>True if the request was deleted</returns>
	public bool DeleteRequest(string code)
	{
		RequestDto request = GetRequestByCode(code);
		if (request is null)
			return false;

		try
		{
			_requestRepository.Delete(request.Id);
		}
		catch
		{
			return false;
		}
		return true;
	}

	/// <summary>
	///  Adds a request.
	/// </summary>
	/// <param name="requestDto">The request to be added as an DTO object</param>
	/// <returns>Newly added request as an DTO object</returns>
	public RequestDto AddRequest(RequestDto requestDto)
	{
		Request request = _mapper.Map<Request>(requestDto);
		Request newRequest = _requestRepository.Insert(request);

		return _mapper.Map<RequestDto>(newRequest);
	}

	/// <summary>
	/// A planet manager.
	/// </summary>
	private IPlanetManager _planetManager;

	/// <summary>
	/// Adds a request.
	/// </summary>
	/// <param name="code">A short string identifying the request</param>
	/// <param name="type">Type of the request</param>
	/// <param name="planetCode">Code of a planet to be explored</param>
	/// <returns>A DTO object storing the newly added request</returns>
	public RequestDto? AddRequest(string code, RequestType type, string planetCode = "")
	{
		// get the planet.
		PlanetDto? planet = null;
		if (!string.IsNullOrEmpty(planetCode))
		{
			planet = _planetManager.GetPlanetByCode(planetCode);

			if (planet == null)
				return null;
		}

		// Store the request.
		RequestDto request = new RequestDto
		{
			Code = code,
			Type = type,
			PlanetId = planet is null ? null : planet.Id,
		};

		return AddRequest(request);
	}


	/// <summary>
	///  Returns all requests.
	/// </summary>
	/// <returns>A list of requests</returns>
	public IList<RequestDto> GetAllRequests()
	{
		IList<Request> requests = _requestRepository.GetAll();
		return _mapper.Map<IList<RequestDto>>(requests);
	}


	/// <summary>
	/// Finds a request by its code.
	/// </summary>
	/// <param name="code">A code string identifying the request</param>
	/// <returns>DTO object of the wanted request or null</returns>
	public RequestDto? GetRequestByCode(string code)
	{
		Request? request = _requestRepository.FindByCode(code);

		if (request is null)
			return null;

		return _mapper.Map<RequestDto>(request);
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="requestRepository">The request repository</param>
	/// <param name="mapper">The mapper</param>
	public RequestManager(IRequestRepository requestRepository, IPlanetManager planetManager, IMapper mapper)
	{
		_requestRepository = requestRepository;
		_planetManager = planetManager;
		_mapper = mapper;
	}

	/// <summary>
	///  Gets a request.
	/// </summary>
	/// <param name="id">Id of the requested request</param>
	/// <returns>A data transformation object</returns>
	public RequestDto? GetRequest(int id)
	{
		Request? request = _requestRepository.FindById(id);

		if (request is null)
			return null;

		return _mapper.Map<RequestDto>(request);
	}

	/// <summary>
	///  The request repository.
	/// </summary>
	private readonly IRequestRepository _requestRepository;

	/// <summary>
	/// The mapper
	/// </summary>
	private readonly IMapper _mapper;


}