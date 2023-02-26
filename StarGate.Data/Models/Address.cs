using System.ComponentModel.DataAnnotations.Schema;

namespace StarGate.Data.Models;

/// <summary>
/// An entity representing a star gate address consisting of 7 symbols.
/// </summary>
//[Index("Symbol1Id", "Symbol2Id", "Symbol3Id", "Symbol4Id", "Symbol5Id", "Symbol6Id", "Symbol7Id", IsUnique = true, Name = "My_Unique_Index")]
public class Address
{
	/// <summary>
	/// Primary key identifying the address
	/// </summary>
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[System.ComponentModel.DataAnnotations.Key()]
	public int Id { get; set; }

	/// <summary>
	/// A foreign key.
	/// </summary>
	public int Symbol1Id { get; set; }

	/// <summary>
	/// 1st symbol of the address
	/// </summary>
	public virtual Symbol Symbol1 { get; set; }

	/// <summary>
	/// A foreign key.
	/// </summary>
	public int Symbol2Id { get; set; }

	/// <summary>
	/// 2nd symbol of the address
	/// </summary>
	public virtual Symbol Symbol2 { get; set; }

	/// <summary>
	/// A foreign key.
	/// </summary>
	public int Symbol3Id { get; set; }

	/// <summary>
	/// 3rd symbol of the address
	/// </summary>
	public virtual Symbol Symbol3 { get; set; }

	/// <summary>
	/// A foreign key.
	/// </summary>
	public int Symbol4Id { get; set; }

	/// <summary>
	/// 4th symbol of the address
	/// </summary>
	public virtual Symbol Symbol4 { get; set; }

	/// <summary>
	/// A foreign key.
	/// </summary>
	public int Symbol5Id { get; set; }

	/// <summary>
	/// 5th symbol of the address
	/// </summary>
	public virtual Symbol Symbol5 { get; set; }

	/// <summary>
	/// A foreign key.
	/// </summary>
	public int Symbol6Id { get; set; }

	/// <summary>
	/// 6th symbol of the address
	/// </summary>
	public virtual Symbol Symbol6 { get; set; }

	/// <summary>
	/// A foreign key.
	/// </summary>
	public int Symbol7Id { get; set; }

	/// <summary>
	/// 7th symbol of the address
	/// </summary>
	public virtual Symbol Symbol7 { get; set; }
}