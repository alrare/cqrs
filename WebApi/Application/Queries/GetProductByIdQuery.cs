using WebApi.Application.Model;
using MediatR;

namespace WebApi.Application.Queries;

public record GetProductByIdQuery(int Id) : IRequest<Product>;
