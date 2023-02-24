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
	/// Updates a symbol.
	/// </summary>
	/// <param name="id">Id of the symbol to be updated</param>
	/// <param name="symbol">DTO object with modified symbol</param>
	/// <returns>IActionResult</returns>
	[HttpPut("symbols/{id}")]
	public IActionResult EditPerson(uint id, [FromBody] SymbolDto symbol)
	{
		SymbolDto? updatedSymbol = _symbolManager.UpdateSymbol(id, symbol);

		if (updatedSymbol is null)
			return NotFound();

		return Ok(updatedSymbol);
	}

	/// <summary>
	/// Adds a symbol.
	/// </summary>
	/// <param name="name">Name of the symbol</param>
	/// <param name="file">Picture of the symbol</param>
	/// <returns>IActionResult</returns>
	[HttpPost("symbols")]
	public IActionResult AddSymbol(string name, IFormFile file)
	{
		// Read the file.
		byte[] data = null;
		try
		{
			using var binaryReader = new BinaryReader(file.OpenReadStream());
			data = binaryReader.ReadBytes((int)file.Length);
		}
		catch
		{
			return StatusCode(500);
		}

		// Store the symbol.
		SymbolDto symbol = new SymbolDto
		{
			Id = default,
			Name = name,
			Image = data
		};

		SymbolDto? newSymbol = _symbolManager.AddSymbol(symbol);

		return CreatedAtAction(nameof(GetSymbol), new { Id = newSymbol.Id }, newSymbol);
	}

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