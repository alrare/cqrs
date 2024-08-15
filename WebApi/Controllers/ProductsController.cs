using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Notifications;
using WebApi.Application.Model;
using WebApi.Application.Commands;
using WebApi.Application.Queries;


namespace WebApi.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IPublisher _publisher;

    public ProductsController(ISender sender, IPublisher publisher)
    {
        _sender = sender;
        _publisher = publisher;
    }


    [HttpGet]
    public async Task<ActionResult> GetProducts()
    {
        var products = await _sender.Send(new GetProductsQuery());
        return Ok(products);
    }


    [HttpGet("{id:int}", Name = "GetProductById")]
    public async Task<ActionResult> GetProductById(int id)
    {
        var product = await _sender.Send(new GetProductByIdQuery(id));
        return Ok(product);
    }


    [HttpPost]
    public async Task<ActionResult> AddProduct([FromBody]Product product)
    {
        var prodToReturn = await _sender.Send(new AddProductCommand(product));
        return CreatedAtRoute("GetProductById", new { id = product.Id }, prodToReturn);

        //Publisher
        //await _publisher.Publish(new ProductAddedNotifications(productToReturn));
    }


    [HttpPut("{id:int}")]    
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
    {
        if (id != product.Id)
        {
            return BadRequest("Producto id no existe");
        }

        var response = await _sender.Send(new UpdateProductCommand(product));
        return Ok(response);
    }


    [HttpDelete("{id:int}")]    
    public async Task<IActionResult> DeleteProduct(int id, [FromBody] Product product)
    {
        if (id != product.Id)
        {
            return BadRequest("Producto id no existe");
        }

        var response = await _sender.Send(new DeleteProductCommand(product));
        
        return Ok(response);
    }
}