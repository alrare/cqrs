using MediatR;
using MinimalApi.Infraestructure.Persistence.Context;
using MinimalApi.Application.Model;
using MinimalApi.Application.Queries;

namespace MinimalApi.Application.Queries.Handlers;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    private readonly DataContext _dataContext;
    public GetProductsHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.GetAllProducts();

    }
}


