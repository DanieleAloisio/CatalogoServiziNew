using CatalogoServizi.Business.Data;
using CatalogoServizi.Common.Pipeline;
using CatalogoServizi.Business.Dto.Common;
using CatalogoServizi.Business.Logic;
using CatalogoServizi.Business.Storage;
using CatalogoServizi.Middleware;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatalogoServizi.Common.MessageBroker;
using System.Configuration;
using CatalogoServizi.Common.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesResponseTypeAttribute(typeof(MessageDto), StatusCodes.Status404NotFound));
    options.Filters.Add(new ProducesResponseTypeAttribute(typeof(MessageDto), StatusCodes.Status500InternalServerError));
});

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConString")));

builder.Services.AddMessageSender();

//
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionPipeline<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LogPipeline<,>));

builder.Services.AddMediatR(typeof(MediatorEntryPoint).Assembly);

//gestore centralizzato message broker

builder.Services.Configure<MessageBrokerConfig>(builder.Configuration.GetSection("Messagging"));





builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesResponseTypeAttribute(typeof(MessageDto), StatusCodes.Status500InternalServerError));
});

builder.Services.AddTransient<UnitOfWork>();
builder.Services.AddTransient<IBaseUnitOfWork, UnitOfWork>();


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

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
