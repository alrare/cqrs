using MediatR;
using MinimalApi.Application.Queries;
using MinimalApi.Application.Behaviors;
using MinimalApi.Infraestructure.Persistence.Context;
using CqrsMediatRFluentValidation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Application.Model;
using MinimalApi.Application.Commands;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLConnection")));

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapGet("api/products", async (IMediator _sender) =>
{
    var products = await _sender.Send(new GetProductsQuery());
    return products;

});

app.MapGet("api/products/{id:int}/", async (IMediator _sender, int id) =>
{
    var product = await _sender.Send(new GetProductByIdQuery(id));
    return product;

});

app.MapPost("api/products", async (IMediator _sender, [FromBody] Product product) =>
{
    var prodToReturn = await _sender.Send(new AddProductCommand(product));
    return prodToReturn;

});


app.MapPut("api/products/{id:int}/", async (IMediator _sender, int id, [FromBody] Product product) =>
{

    //if (id != product.Id)
    //{
    //    return Console.WriteLine("Producto id no existe");
    //}

    var response = await _sender.Send(new UpdateProductCommand(product));
    return response;

});


app.MapDelete("api/products/{id:int}/", async (IMediator _sender, int id, [FromBody] Product product) =>
{
    //if (id != product.Id)
    //{
    //    return Console.WriteLine("Producto id no existe");
    //}

    var response = await _sender.Send(new DeleteProductCommand(product));

    return response;

});

app.Run();
