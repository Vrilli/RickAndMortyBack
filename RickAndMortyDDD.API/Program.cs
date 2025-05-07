using Refit;
using RickAndMortyDDD.Application.Services;
using RickAndMortyDDD.Infrastructure.ExternalApis;
using RickAndMortyDDD.Domain.Repositories;
using RickAndMortyDDD.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddRefitClient<IRickAndMortyApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://rickandmortyapi.com/api"));

 builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IEpisodeRepository, EpisodeRepository>();
builder.Services.AddScoped<IEpisodeService, EpisodeService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseSwagger();
app.UseCors("AllowAll");
app.UseSwaggerUI();

app.MapControllers();

app.Run();
