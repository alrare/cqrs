using MediatR;
using MinimalApi.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Application.Commands;
using MinimalApi.Application.Model;

namespace MinimalApi.Application.Commands.Handlers;

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
