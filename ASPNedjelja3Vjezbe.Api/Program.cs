using ASPNedjelja3.DataAccess;
using ASPNedjelja3Vjezbe.Api;
using ASPNedjelja3Vjezbe.Application.Logging;
using ASPNedjelja3Vjezbe.Application.UseCases.Commands;
using ASPNedjelja3Vjezbe.Application.UseCases.Queries;
using ASPNedjelja3Vjezbe.Implementation;
using ASPNedjelja3Vjezbe.Implementation.Logging;
using ASPNedjelja3Vjezbe.Implementation.UseCases.Commands;
using ASPNedjelja3Vjezbe.Implementation.UseCases.Queries.Ef;
using ASPNedjelja3Vjezbe.Implementation.UseCases.Queries.SP;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddTransient<Vjezbe3DbContext>();
builder.Services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
builder.Services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();
builder.Services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
builder.Services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
builder.Services.AddTransient<UseCaseHandler>();
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
