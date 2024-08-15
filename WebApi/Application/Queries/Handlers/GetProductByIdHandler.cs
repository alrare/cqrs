using MediatR;
using WebApi.Infraestructure.Persistence.Context;
using WebApi.Application.Model;
using WebApi.Application.Queries;

namespace WebApi.Application.Queries.Handlers;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly DataContext _dataContext;
    public GetProductByIdHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) =>
        await _dataContext.GetProductById(request.Id);
}
