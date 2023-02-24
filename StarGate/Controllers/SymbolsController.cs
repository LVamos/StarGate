using Microsoft.AspNetCore.Mvc;

using StarGate.Business.Models;
using StarGate.Business.Models.Interfaces;

namespace StarGate.Controllers;

/// <summary>
///  A symbols controller.
/// </summary>
[Route("api")]
[ApiController]
public class SymbolsController : ControllerBase
{
	/// <summary>
	///  Deletes a symbol.
	/// </summary>
	/// <param name="id">Id of the symbol to be deleted</param>
	/// <returns>IActionResult</returns>
	[HttpDelete("symbols/{id}")]
	public IActionResult DeleteSymbol(uint id)
	{
		if (_symbolManager.DeleteSymbol(id))
			return Ok();

		return NotFound();
	}

	/// <summary>
	///  Gets a symbol.
	/// </summary>
	/// <param name="id"></param>
	/// <returns>IActionResult</returns>
	[HttpGet("symbols/{id}")]
	public IActionResult GetSymbol(uint id)
	{
		SymbolDto? symbol = _symbolManager.GetSymbol(id);

		if (symbol is null)
			return NotFound();
		return Ok(symbol);
	}

	/// <summary>
	///  Gets all symbols.
	/// </summary>
	/// <returns>ienumeration of symbols</returns>
	[HttpGet("symbols")]
	public IEnumerable<SymbolDto> GetSymbols() => _symbolManager.GetAllSymbols();

	/// <summary>
	///  A symbol manager.
	/// </summary>
	private readonly ISymbolManager _symbolManager;

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="symbolManager">A symbol manager</param>
	public SymbolsController(ISymbolManager symbolManager) => _symbolManager = symbolManager;
}