using StarGate.Data.Models;

namespace StarGate.Data.Interfaces;

/// <summary>
/// An interface for a repository of planets
/// </summary>
public interface IPlanetRepository : IBaseRepository<Planet>
{
	bool Delete(string code);
}
