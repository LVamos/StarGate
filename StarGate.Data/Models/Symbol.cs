using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarGate.Data.Models;

/// <summary>
/// Describes a star gate symbol.
/// </summary>
[Index(nameof(Symbol.Name), IsUnique = true)]
public class Symbol
{
	/// <summary>
	/// Primary key identifying the symbol
	/// </summary>
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Key()]
	public uint Id { get; set; }

	/// <summary>
	/// Unique name of the symbol
	/// </summary>
	[Required]
	[StringLength(20)]
	public string Name { get; set; } = "";

	/// <summary>
	/// Picture of the symbol.
	/// </summary>
	[Required]
	public byte[] Image { get; set; }
}

