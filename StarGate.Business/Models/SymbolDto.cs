namespace StarGate.Business.Models;

/// <summary>
///  A data transfer object for a symbol
/// </summary>
public class SymbolDto
{
	/// <summary>
	/// Id of the symbol
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	/// Code of the symbol
	/// </summary>
	public string Code { get; set; }

	/// <summary>
	/// Name of the symbol
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// Picture of the symbol.
	/// </summary>
	public byte[] Image { get; set; }
}
