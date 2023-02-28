using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

using StarGate.Business.Managers;
using StarGate.Data.Repositories;

namespace StargateTests;

/// <summary>
/// Tests the symbol manager
/// </summary>
[TestClass]
public class SymbolManagerTests : BaseTestClass
{
	private IFormFile LoadImage(string fileName)
	{
		string path = Path.Combine(Directory.GetCurrentDirectory(), "Images", fileName);

		// Load the file.
		FormFile file = null;
		try
		{
			using FileStream stream = File.OpenRead(path);
			file = new(stream, 0, stream.Length, null, fileName)
			{
				Headers = new HeaderDictionary(),
				ContentType = "image/jpg"
			};
		}
		catch (Exception)
		{
			Assert.Fail();
			throw;
		}

		return file;
	}

	[TestMethod]
	public void seedSymbols()
	{
		// Delete all rows in Symbols table.
		_dbContext.Symbols.RemoveRange(_dbContext.Symbols);

		// Add some symbols.
		_symbolManager.AddSymbol("s1", "Serpens Caput", LoadImage("Serpens Caput.jpg"));
		_symbolManager.AddSymbol("s2", "Libra", LoadImage("Libra.jpg"));
		_symbolManager.AddSymbol("s3", "Centaurus", LoadImage("Centaurus.jpg"));
		_symbolManager.AddSymbol("s4", "Crater", LoadImage("Crater.jpg"));
		_symbolManager.AddSymbol("s5", "Earth", LoadImage("Earth.jpg"));

		// Verify that the symbols were added.
		Assert.AreEqual(5, _dbContext.Symbols.Count());
	}

	/// <summary>
	/// The symbol manager to test
	/// </summary>
	private SymbolManager _symbolManager;

	/// <summary>
	/// Symbol repository.
	/// </summary>
	private SymbolRepository _symbolRepository;

	/// <summary>
	/// Cleans up the test class
	/// </summary>
	[TestCleanup]
	public override void cleanup()
	{
		_symbolManager = null;
		_symbolRepository = null;

		base.cleanup();
	}

	/// <summary>
	/// Initializes the test class
	/// </summary>
	[TestInitialize]
	public override void init()
	{
		base.init();

		// Prepare the symbol manager.
		_symbolRepository = new(_dbContext);
		_symbolManager = new(_symbolRepository, _mapper);
	}
}
