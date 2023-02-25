using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;

namespace StarGate.Data.Models;

/// <summary>
/// An entity representing a star gate address consisting of 7 symbols.
/// </summary>
[Index(nameof(Address.Symbol1Id), IsUnique = true)]
[Index(nameof(Address.Symbol2Id), IsUnique = true)]
[Index(nameof(Address.Symbol3Id), IsUnique = true)]
[Index(nameof(Address.Symbol4Id), IsUnique = true)]
[Index(nameof(Address.Symbol5Id), IsUnique = true)]
[Index(nameof(Address.Symbol6Id), IsUnique = true)]
[Index(nameof(Address.Symbol7Id), IsUnique = true)]
public class Address
{
	/// <summary>
	/// Primary key identifying the address
	/// </summary>
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[System.ComponentModel.DataAnnotations.Key()]
	public uint Id { get; set; }

	/// <summary>
	/// A foreign key.
	/// </summary>
	public uint Symbol1Id { get; set; }

	/// <summary>
	/// 1st symbol of the address
	/// </summary>
	public virtual Symbol Symbol1 { get; set; }

	/// <summary>
	/// A foreign key.
	/// </summary>
	public uint Symbol2Id { get; set; }

	/// <summary>
	/// 2nd symbol of the address
	/// </summary>
	public virtual Symbol Symbol2 { get; set; }

	/// <summary>
	/// A foreign key.
	/// </summary>
	public uint Symbol3Id { get; set; }

	/// <summary>
	/// 3rd symbol of the address
	/// </summary>
	public virtual Symbol Symbol3 { get; set; }

	/// <summary>
	/// A foreign key.
	/// </summary>
	public uint Symbol4Id { get; set; }

	/// <summary>
	/// 4th symbol of the address
	/// </summary>
	public virtual Symbol Symbol4 { get; set; }

	/// <summary>
	/// A foreign key.
	/// </summary>
	public uint Symbol5Id { get; set; }

	/// <summary>
	/// 5th symbol of the address
	/// </summary>
	public virtual Symbol Symbol5 { get; set; }

	/// <summary>
	/// A foreign key.
	/// </summary>
	public uint Symbol6Id { get; set; }

	/// <summary>
	/// 6th symbol of the address
	/// </summary>
	public virtual Symbol Symbol6 { get; set; }

	/// <summary>
	/// A foreign key.
	/// </summary>
	public uint Symbol7Id { get; set; }

	/// <summary>
	/// 7th symbol of the address
	/// </summary>
	public virtual Symbol Symbol7 { get; set; }
}