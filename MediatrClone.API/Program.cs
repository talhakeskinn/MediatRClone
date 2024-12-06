using MediatrClone.API.Queries;
using MediatrClone.Library;
using MediatrClone.Library.Interfaces;
var MiddlewareClone = MediatrClone.Library.ServiceCollectionExtension.UseCustomMediator;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCustomMediator(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.BuildServiceProvider().UseCustomMediator();
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

