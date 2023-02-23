namespace StarGate.Business.Models;

/// <summary>
///  A data transfer object for a symbol
/// </summary>
public class SymbolDto
{
	/// <summary>
	/// Id of the symbol
	/// </summary>
	public uint Id { get; set; }

	/// <summary>
	/// Name of the symbol
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// Name of the image file stored in Images folder
	/// </summary>
	public string ImageName { get; set; }

	/// <summary>
	/// URI of the image file
	/// </summary>
	public string ImageURI { get; set; }
}

