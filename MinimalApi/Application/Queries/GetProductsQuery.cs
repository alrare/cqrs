using MinimalApi.Application.Model;
using MediatR;

namespace MinimalApi.Application.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
}