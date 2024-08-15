using MinimalApi.Application.Model;
using MediatR;

namespace MinimalApi.Application.Queries;

public record GetProductByIdQuery(int Id) : IRequest<Product>;
