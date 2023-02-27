using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.OpenApi.Models;

using StarGate.Business;
using StarGate.Business.Interfaces;
using StarGate.Business.Managers;
using StarGate.Data;
using StarGate.Data.Interfaces;
using StarGate.Data.Repositories;

using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(AutomapperConfigurationProfile));

// Repositories and managers
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ITeamManager, TeamManager>();

builder.Services.AddScoped<ISymbolRepository, SymbolRepository>();
builder.Services.AddScoped<ISymbolManager, SymbolManager>(); // Tento øádek jsme pøidali

builder.Services.AddScoped<IPlanetRepository, PlanetRepository>();
builder.Services.AddScoped<IPlanetManager, PlanetManager>();

builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IAddressManager, AddressManager>();



string connectionString = builder.Configuration.GetConnectionString("LocalStargateConnection");
builder.Services.AddDbContext<StarGateDbContext>(
	o => o.UseSqlServer(connectionString)
	.UseLazyLoadingProxies()
	.ConfigureWarnings(x => x.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning)));

// swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
	o =>
	o.SwaggerDoc("stargate", new OpenApiInfo
	{
		Version = "v1",
		Title = "Hvìzdná brána",
		Description = "Webové API pro ovládání hvìzdné brány"
	}));

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
	.AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(o =>
{
	o.SwaggerEndpoint("stargate/swagger.json", "Hvìzdná brána - verze 1");
});

app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();
