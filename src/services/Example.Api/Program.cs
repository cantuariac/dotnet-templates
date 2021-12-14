using Core.Api.Configurations;
using Example.Api;
using Example.Api.Data;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>();

// Add services to the container.

builder.Services.ResolvePostgres<ExampleDbContext>(configuration.GetConnectionString("PostgresConnection"));
builder.Services.ResolveMongoDB(configuration.GetConnectionString("MongoConnection"));
builder.Services.ResolveRedis(configuration.GetConnectionString("RedisConnection"));

builder.Services.ResolveJWT(configuration.GetSection("JWT:Secret").Value);

builder.Services.ResolveSwagger();
builder.Services.ResolveDependencyInjection();
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
app.UseAuthentication();

app.MapControllers();

app.Run();
