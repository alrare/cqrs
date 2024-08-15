using MediatR;
using WebApi.Infraestructure.Persistence.Context;
using WebApi.Application.Model;
using WebApi.Application.Queries;

namespace WebApi.Application.Queries.Handlers;

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


