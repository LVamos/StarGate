using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using StarGate.Business;
using StarGate.Business.Managers;
using StarGate.Business.Models;
using StarGate.Data;
using StarGate.Data.Models;
using StarGate.Data.Repositories;

namespace StargateTests;

/// <summary>
/// Tests the symbol manager
/// </summary>
[TestClass]
public class Tests
{
	/// <summary>
	/// The team manager to test
	/// </summary>
	private TeamManager _teamManager;

	/// <summary>
	///  Database context.
	/// </summary>
	protected StarGateDbContext _dbContext;

	/// <summary>
	/// Automapper instance.
	/// </summary>
	protected Mapper _mapper;


	private IFormFile LoadImage(string fileName)
	{
		string path = Path.Combine(Directory.GetCurrentDirectory(), @"Assets\Images", fileName);

		// Load the file.
		try
		{
			FileStream stream = File.OpenRead(path);
			FormFile file = new(stream, 0, stream.Length, null, fileName)
			{
				Headers = new HeaderDictionary(),
				ContentType = "image/jpg"
			};

			return file;
		}
		catch (Exception)
		{
			Assert.Fail();
			throw;
		}
	}

	[TestMethod]
	public void SeedDatabase()
	{
		EmptyDatabase();
		AddTeams();
		AddSymbols();
		AddPlanets();
		AddRequests();
	}

	/// <summary>
	/// Adds some randomly generated requests into database and verifies that they were added.
	/// </summary>
	private void AddRequests()
	{
		Random random = new();

		for (int i = 1; i <= 30; i++)
		{
			string code = $"r{i.ToString()}";
			if (random.Next(1, 50) <= 25)
				_requestManager.AddRequest(code, RequestType.Diagnostics);
			else _requestManager.AddRequest(code, RequestType.Open, $"p{random.Next(1, 5).ToString()}");
		}

		// Verify that 30 requests are in the database.
		Assert.AreEqual(30, _dbContext.Requests.Count());
	}

	/// <summary>
	/// Adds some planets into database and verifies that they were added.
	/// </summary>
	private void AddPlanets()
	{
		_planetManager.AddPlanet("p1", "Altair", string.Empty, false, PlanetSafety.Neutral, "s1", "s2", "s1", "s4", "s3", "s5", "s1");
		_planetManager.AddPlanet("p2", "Aldebaran", string.Empty, false, PlanetSafety.Neutral, "s4", "s1", "s5", "s4", "s3", "s5", "s1");
		_planetManager.AddPlanet("p3", "Antares", "t1", true, PlanetSafety.Friendly, "s5", "s5", "s2", "s4", "s3", "s5", "s1");
		_planetManager.AddPlanet("p4", "Arcturus", "t2", true, PlanetSafety.Unfriendly, "s1", "s1", "s5", "s2", "s3", "s5", "s1");
		_planetManager.AddPlanet("p5", "Betelgeuse", "t3", true, PlanetSafety.Friendly, "s4", "s4", "s1", "s3", "s3", "s5", "s1");

		// Verify that 5 planets were added.
		Assert.AreEqual(5, _dbContext.Planets.Count());
	}

	/// <summary>
	///  Adds some teams into database and verifies that they were added.
	/// </summary>
	private void AddTeams()
	{
		// Add some teams.
		_teamManager.AddTeam(new TeamDto
		{
			Code = "t1",
			Name = "SG1",
			Members = 10
		});

		_teamManager.AddTeam(new TeamDto
		{
			Code = "t2",
			Name = "SG2",
			Members = 20
		});

		_teamManager.AddTeam(new TeamDto
		{
			Code = "t3",
			Name = "SG3",
			Members = 30
		});

		_teamManager.AddTeam(new TeamDto
		{
			Code = "t4",
			Name = "SG4",
			Members = 40
		});

		_teamManager.AddTeam(new TeamDto
		{
			Code = "t5",
			Name = "SG5",
			Members = 50
		});

		// Verify that the teams were added.
		Assert.AreEqual(5, _dbContext.Teams.Count());
	}

	/// <summary>
	/// Adds some symbols into database and verifies that they were added.
	/// </summary>
	private void AddSymbols()
	{
		_symbolManager.AddSymbol("s1", "Serpens Caput", LoadImage("Serpens Caput.jpg"));
		_symbolManager.AddSymbol("s2", "Libra", LoadImage("Libra.jpg"));
		_symbolManager.AddSymbol("s3", "Centaurus", LoadImage("Centaurus.jpg"));
		_symbolManager.AddSymbol("s4", "Crater", LoadImage("Crater.jpg"));
		_symbolManager.AddSymbol("s5", "Earth", LoadImage("Earth.jpg"));

		// Verify that the symbols were added.
		Assert.AreEqual(5, _dbContext.Symbols.Count());
	}

	/// <summary>
	/// Deletes all data from the database.
	/// </summary>
	private void EmptyDatabase()
	{
		// Delete requests.
		foreach (RequestDto r in _requestManager.GetAllRequests())
			_requestManager.DeleteRequest(r.Code);

		// Remove planets.
		foreach (PlanetDto p in _planetManager.GetAllPlanets())
			_planetManager.DeletePlanet(p.Id);

		// Delete teams.
		foreach (TeamDto t in _teamManager.GetAllTeams())
			_teamManager.DeleteTeam(t.Id);

		// Delete addresses.
		foreach (AddressDto a in _addressManager.GetAllAddresses())
			_addressManager.DeleteAddress(a.Id);

		// Delete symbols.
		foreach (SymbolDto s in _symbolManager.GetAllSymbols())
			_symbolManager.DeleteSymbol(s.Id);
	}

	/// <summary>
	/// The symbol manager to test
	/// </summary>
	private SymbolManager _symbolManager;

	/// <summary>
	/// Planet repository.
	/// </summary>
	private PlanetRepository _planetRepository;

	/// <summary>
	///  An address manager.
	/// </summary>
	private AddressManager _addressManager;

	/// <summary>
	///  Planet manager.
	/// </summary>
	private PlanetManager _planetManager;

	/// <summary>
	/// A request repository.
	/// </summary>
	private RequestRepository _requestRepository;

	/// <summary>
	/// A request manager.
	/// </summary>
	private RequestManager _requestManager;

	/// <summary>
	/// Cleans up the test class
	/// </summary>
	[TestCleanup]
	public void cleanup() => _dbContext?.Dispose();

	/// <summary>
	/// Initializes the test class
	/// </summary>
	[TestInitialize]
	public void init()
	{
		// Prepare database.
		string connectionString = @"Server=(localdb)\mssqllocaldb;Database=StargateDatabase;Trusted_Connection=true;MultipleActiveResultSets=true";
		var optionsBuilder = new DbContextOptionsBuilder<StarGateDbContext>();
		optionsBuilder.UseSqlServer(connectionString);
		optionsBuilder.UseLazyLoadingProxies();
		optionsBuilder.ConfigureWarnings(x => x.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning));
		_dbContext = new StarGateDbContext(optionsBuilder.Options);

		// Configure mapper.
		var configuration = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperConfigurationProfile>());
		_mapper = new(configuration);

		// Prepare managers.
		TeamRepository teamRepository = new(_dbContext);
		_teamManager = new(teamRepository, _mapper);

		SymbolRepository symbolRepository = new(_dbContext);
		_symbolManager = new(symbolRepository, _mapper);

		AddressRepository addressRepository = new(_dbContext);
		_addressManager = new(addressRepository, _symbolManager, _mapper);

		PlanetRepository planetRepository = new(_dbContext);
		_planetManager = new PlanetManager(planetRepository, _addressManager, _teamManager, _mapper);

		_requestRepository = new(_dbContext);
		_requestManager = new(_requestRepository, _planetManager, _mapper);
	}
}
