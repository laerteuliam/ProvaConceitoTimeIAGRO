using IAGRO.Challenge.Api.Extensions;
using IAGRO.Challenge.Database.Catalog;
using IAGRO.Challenge.Database.Core;
using IAGRO.Challenge.Domain.Catalog.Interfaces;
using IAGRO.Challenge.Domain.Core.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(opts =>
{
    var enumConverter = new JsonStringEnumConverter();
    opts.JsonSerializerOptions.Converters.Add(enumConverter);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDataSource, DataSource>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddMediatRApi();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();