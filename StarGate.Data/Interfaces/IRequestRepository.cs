using StarGate.Data.Models;

namespace StarGate.Data.Interfaces;

/// <summary>
/// An interface for a repository of requests
/// </summary>
public interface IRequestRepository : IBaseRepository<Request>
{
	/// <summary>
	/// Finds a request by its code.
	/// </summary>
	/// <param name="code">A code string identifying the request</param>
	/// <returns>DTO object of the wanted request or null</returns>
	Request? FindByCode(string code);
}
