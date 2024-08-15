using WebApi.Application.Model;
using MediatR;

namespace WebApi.Application.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
}