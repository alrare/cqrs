using MediatR;
using WebApi.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.Commands;
using WebApi.Application.Model;

namespace WebApi.Application.Commands.Handlers;

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
