using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using StarGate.Business;
using StarGate.Data;

namespace StargateTests;

/// <summary>
/// Tests for the SymbolManager class
/// </summary>
[TestClass]
public abstract class BaseTestClass
{
	/// <summary>
	///  Database context.
	/// </summary>
	protected StarGateDbContext _dbContext;

	/// <summary>
	/// Automapper instance.
	/// </summary>
	protected Mapper _mapper;

	/// <summary>
	/// Initializes the test class
	/// </summary>
	[TestInitialize]
	public virtual void init()
	{
		// Prepare database.
		string connectionString = @"Server=(localdb)\\mssqllocaldb;Database=StargateDatabase;Trusted_Connection=true;MultipleActiveResultSets=true";
		var optionsBuilder = new DbContextOptionsBuilder<StarGateDbContext>();
		optionsBuilder.UseSqlServer(connectionString);
		optionsBuilder.UseLazyLoadingProxies();
		optionsBuilder.ConfigureWarnings(x => x.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning));
		_dbContext = new StarGateDbContext(optionsBuilder.Options);

		// Configure mapper.
		var configuration = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperConfigurationProfile>());
		_mapper = new Mapper(configuration);
	}

	/// <summary>
	/// Cleans up the test class
	/// </summary>
	[TestCleanup]
	public virtual void cleanup()
	{
		_mapper = null;
		_dbContext?.Dispose();
		_dbContext = null;
	}

	[TestMethod]
	public void seedSymbols()
	{
	}
}