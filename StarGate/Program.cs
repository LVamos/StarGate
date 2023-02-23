using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using StarGate.Business;
using StarGate.Business.Managers;
using StarGate.Business.Models.Interfaces;
using StarGate.Data;
using StarGate.Data.Interfaces;
using StarGate.Data.Repositories;

using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(AutomapperConfigurationProfile));

// Repositories and managers
builder.Services.AddScoped<ITeamRepository, TeamRepository>();

builder.Services.AddScoped<ISymbolRepository, SymbolRepository>();
builder.Services.AddScoped<ISymbolManager, SymbolManager>(); // Tento øádek jsme pøidali


builder.Services.AddScoped<IPlanetRepository, PlanetRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();


string connectionString = builder.Configuration.GetConnectionString("LocalStargateConnection");
builder.Services.AddDbContext<StarGateDbContext>(
	o => o.UseSqlServer(connectionString)
	.UseLazyLoadingProxies()
	.ConfigureWarnings(x => x.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning)));
builder.Services.AddControllers()
	.AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

WebApplication app = builder.Build();

app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();
