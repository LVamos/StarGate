﻿namespace StarGate.Business.Models;

/// <summary>
///  A data transfer object for an address
/// </summary>
public class AddressDto
{
	/// <summary>
	/// Id of the address
	/// </summary>
	public int Id { get; set; }

	public uint Symbol1id { get; set; }
	public uint Symbol2Id { get; set; }
	public uint Symbol3Id { get; set; }
	public uint Symbol4Id { get; set; }
	public uint Symbol5Id { get; set; }
	public uint Symbol6Id { get; set; }
	public uint Symbol7Id { get; set; }

	/// <summary>
	/// 1st symbol of the address
	/// </summary>
	public SymbolDto Symbol1 { get; set; }

	/// <summary>
	/// 2nd symbol of the address
	/// </summary>
	public SymbolDto Symbol2 { get; set; }

	/// <summary>
	/// 3rd symbol of the address
	/// </summary>
	public SymbolDto Symbol3 { get; set; }

	/// <summary>
	/// 4th symbol of the address
	/// </summary>
	public SymbolDto Symbol4 { get; set; }

	/// <summary>
	/// 5th symbol of the address
	/// </summary>
	public SymbolDto Symbol5 { get; set; }

	/// <summary>
	/// 6th symbol of the address
	/// </summary>
	public SymbolDto Symbol6 { get; set; }

	/// <summary>
	/// 7th symbol of the address
	/// </summary>
	public SymbolDto Symbol7 { get; set; }
}