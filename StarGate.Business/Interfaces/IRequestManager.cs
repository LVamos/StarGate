using StarGate.Business.Models;

namespace StarGate.Business.Interfaces;

/// <summary>
/// An interface for request manager.
/// </summary>
public interface IRequestManager
{
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
