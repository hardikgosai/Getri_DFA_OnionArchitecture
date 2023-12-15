using DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<GetriDfaonionArchiContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OnionConnections")));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserProfileRepository, UserProfileRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
