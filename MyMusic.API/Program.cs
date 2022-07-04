using Microsoft.EntityFrameworkCore;
using MyMusic.Core.Interfaces;
using MyMusic.Data.DataContext;
using MyMusic.Services;
using MyMusic.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MyMusicDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IMusicRepository, MusicRepository>();
builder.Services.AddTransient<IArtistRepository, ArtistRepository>();

builder.Services.AddTransient<IMusicService, MusicService>();
builder.Services.AddTransient<IArtistService, ArtistService>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

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
