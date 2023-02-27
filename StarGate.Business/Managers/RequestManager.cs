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
	public RequestManager(IRequestRepository requestRepository, IMapper mapper)
	{
		_requestRepository = requestRepository;
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