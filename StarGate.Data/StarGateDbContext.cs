using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using StarGate.Data.Models;

namespace StarGate.Data;
public class StarGateDbContext : DbContext
{
	/// <summary>
	/// A table storing star gate symbols.
	/// </summary>
	public DbSet<Symbol> Symbols { get; set; }

	/// <summary>
	/// A table storing planet adresses.
	/// </summary>
	public DbSet<Address> Addresses { get; set; }

	/// <summary>
	/// A table storing star gate teams.
	/// </summary>
	public DbSet<Team> Teams { get; set; }

	/// <summary>
	/// A table storing planets for Star gate project.
	/// </summary>
	public DbSet<Planet> Planets { get; set; }

	/// <summary>
	/// A table storing a queue with star gate requests.
	/// </summary>
	public DbSet<Request> Requests { get; set; }

	/// <summary>
	/// Configures the model.
	/// </summary>
	/// <param name="builder">The model to be configured</param>
	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		// Change delete behavior.
		foreach (EntityType type in builder.Model.GetEntityTypes())
		{
			type.SetTableName(type.DisplayName());

			IEnumerable<ForeignKey> keys = type.GetForeignKeys()
			 .Where(k => !k.IsOwnership && k.DeleteBehavior == DeleteBehavior.Cascade);

			foreach (ForeignKey k in keys)
				k.DeleteBehavior = DeleteBehavior.Restrict;
		}

		builder.Entity<Symbol>().HasData(
			new Symbol
			{
				Id = 1,
				Name = "losos",
				ImageName = "losos.jpg",
				ImageURI = "https://localhost:7230/images/losos.jpg"
			},
			new Symbol
			{
				Id = 2,
				Name = "kot",
				ImageName = "kot.jpg",
				ImageURI = "https://localhost:7230/images/kot.jpg"
			}
			);
	}

	public StarGateDbContext(DbContextOptions<StarGateDbContext> options) : base(options) { }
}
