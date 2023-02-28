using Microsoft.AspNetCore.Mvc;

using StarGate.Business.Interfaces;
using StarGate.Business.Models;

namespace StarGate.Controllers;

/// <summary>
///  A symbols controller.
/// </summary>
[Route("api")]
[ApiController]
public class SymbolsController : ControllerBase
{
	/// <summary>
	/// Updates a symbol.
	/// </summary>
	/// <param name="id">Id of the symbol to be updated</param>
	/// <param name="symbol">DTO object with modified symbol</param>
	/// <returns>IActionResult</returns>
	[HttpPut("symbols")]
	public IActionResult EditSymbol(string code, [FromBody] SymbolDto symbol)
	{
		SymbolDto? updatedSymbol = _symbolManager.UpdateSymbol(code, symbol);

		if (updatedSymbol is null)
			return NotFound();

		return Ok(updatedSymbol);
	}

	/// <summary>
	/// Adds a symbol.
	/// </summary>
	/// <param name="code">A short string identifying the symbol</param>
	/// <param name="name">Name of the symbol</param>
	/// <param name="file">Picture of the symbol</param>
	/// <returns>IActionResult</returns>
	[HttpPost("symbols")]
	public IActionResult AddSymbol(string code, string name, IFormFile file)
	{
		// Store the symbol.
		SymbolDto? symbol = _symbolManager.AddSymbol(code, name, file);
		if (symbol is null)
			return Problem(title: "Error", detail: "The symbol could not be added.", statusCode: 500);

		return CreatedAtAction(nameof(GetSymbol), new { Code = symbol.Code }, symbol);
	}

	/// <summary>
	///  Deletes a symbol.
	/// </summary>
	/// <param name="code">A short string identifying the symbol to be deleted</param>
	/// <returns>IActionResult</returns>
	[HttpDelete("symbols")]
	public IActionResult DeleteSymbol(string code)
	{
		if (_symbolManager.DeleteSymbol(code))
			return Ok();

		return Problem(title: "Error", detail: "Unable to delete the symbol", statusCode: 500);
	}

	/// <summary>
	///  Gets a symbol.
	/// </summary>
	/// <param name="code">A short string identifying the symbol</param>
	/// <returns>IActionResult</returns>
	[HttpGet("symbols/{code}")]
	public IActionResult GetSymbol(string code)
	{
		SymbolDto? symbol = _symbolManager.GetSymbolByCode(code);

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