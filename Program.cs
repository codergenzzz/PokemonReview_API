using Microsoft.EntityFrameworkCore;
using PokemonReview;
using PokemonReview.Data;
using PokemonReview.Interfaces;
using PokemonReview.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// life-cycle of DI
builder.Services.AddTransient<Seed>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// ??ng kí DI
builder.Services.AddScoped<IPokemonRepos, PokemonRepos>();
builder.Services.AddScoped<ICategoryRepos, CategoyRepos>();
builder.Services.AddScoped<ICountryRepos, CountryRepos>();
builder.Services.AddScoped<IOwnerRepos, OwnerRepos>();
builder.Services.AddScoped<IReviewerRepos, ReviewerRepos>();
builder.Services.AddScoped<IReviewRepos, ReviewRepos>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connect DbContext - Sql server to migration
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}

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
