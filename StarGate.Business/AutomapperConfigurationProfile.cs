using AutoMapper;

using StarGate.Business.Models;
using StarGate.Data.Models;

namespace StarGate.Business;

/// <summary>
///  A class for automapper configuration
/// </summary>
public class AutomapperConfigurationProfile : Profile
{
	/// <summary>
	/// Constructor
	/// </summary>
	public AutomapperConfigurationProfile()
	{
		CreateMap<Symbol, SymbolDto>();
		CreateMap<SymbolDto, Symbol>();

		CreateMap<Team, TeamDto>();
		CreateMap<TeamDto, Team>();

		CreateMap<Planet, PlanetDto>();
		CreateMap<PlanetDto, Planet>();

		CreateMap<Address, AddressDto>();
		CreateMap<AddressDto, Address>();

		CreateMap<Request, RequestDto>();
		CreateMap<RequestDto, Request>();
	}
}
