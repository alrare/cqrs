using MediatR;
using WebApi.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.Commands;
using WebApi.Application.Model;

namespace WebApi.Application.Commands.Handlers;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Product>
{
    private readonly DataContext _context;

    public DeleteProductHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        _context.Products.Remove(request.Product);

        await _context.SaveChangesAsync();

        return request.Product;
    }
}
