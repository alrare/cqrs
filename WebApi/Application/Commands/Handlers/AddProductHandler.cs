using MediatR;
using WebApi.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.Commands;
using WebApi.Application.Model;

namespace WebApi.Application.Commands.Handlers;

public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
{
    private readonly DataContext _context;

    public AddProductHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        _context.Products.Add(request.Product);
        await _context.SaveChangesAsync();
        return request.Product;
    }
}
