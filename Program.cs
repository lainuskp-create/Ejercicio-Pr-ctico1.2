using CacheDemo.Services;   // 
using Microsoft.Extensions.Options;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Configuración de CacheOptions desde appsettings.json
builder.Services.Configure<CacheOptions>(
    builder.Configuration.GetSection("Cache"));

//Registrar Redis ConnectionMultiplexer como Singleton
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var options = sp.GetRequiredService<IOptions<CacheOptions>>().Value;
    return ConnectionMultiplexer.Connect(options.ConnectionString);
});

//Registrar el Serializador
builder.Services.AddSingleton<ISerializer, SystemTextJsonSerializer>();

//Registrar el servicio de caché genérico
builder.Services.AddScoped(typeof(ICacheService<>), typeof(RedisCacheService<>));

//Los servicios que ya trae tu proyecto
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
