using StarGate.Business.Models;
using StarGate.Data.Models;

namespace StarGate.Business.Interfaces;

/// <summary>
/// An interface for request manager.
/// </summary>
public interface IRequestManager
{
	/// <summary>
	/// Adds a request.
	/// </summary>
	/// <param name="code">A short string identifying the request</param>
	/// <param name="type">Type of the request</param>
	/// <param name="planetCode">Code of a planet to be explored</param>
	/// <returns>A DTO object storing the newly added request</returns>
	RequestDto? AddRequest(string code, RequestType type, string planetCode = "");


	/// <summary>
	///  Adds a request.
	/// </summary>
	/// <param name="requestDto">The request to be added as an DTO object</param>
	/// <returns>Newly added request as an DTO object</returns>
	RequestDto AddRequest(RequestDto requestDto);

	/// <summary>
	/// Deletes a request.
	/// </summary>
	/// <param name="code">A short string identifying the request</param>
	/// <returns>True if the request was deleted</returns>
	bool DeleteRequest(string code);

	/// <summary>
	///  Returns all requests.
	/// </summary>
	/// <returns>A list of requests</returns>
	IList<RequestDto> GetAllRequests();

	/// <summary>
	///  Gets a request.
	/// </summary>
	/// <param name="id">Id of the requested request</param>
	/// <returns>A data transformation object</returns>
	RequestDto? GetRequest(int id);

	/// <summary>
	/// Finds a request by its code.
	/// </summary>
	/// <param name="code">A code string identifying the request</param>
	/// <returns>DTO object of the wanted request or null</returns>
	RequestDto? GetRequestByCode(string code);
}
