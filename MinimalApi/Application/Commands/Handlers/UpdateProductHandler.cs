using MediatR;
using MinimalApi.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Application.Commands;
using MinimalApi.Application.Model;

namespace MinimalApi.Application.Commands.Handlers;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
{
    private readonly DataContext _context;

    public UpdateProductHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        _context.Products.Update(request.Product);

        await _context.SaveChangesAsync();

        return request.Product;
    }
}
