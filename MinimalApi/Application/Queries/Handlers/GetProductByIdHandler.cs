using MediatR;
using MinimalApi.Infraestructure.Persistence.Context;
using MinimalApi.Application.Model;
using MinimalApi.Application.Queries;

namespace MinimalApi.Application.Queries.Handlers;

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
