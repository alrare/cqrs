using MinimalApi.Application.Model;
using MediatR;

namespace MinimalApi.Application.Commands;

//Utilizar DTO
public record UpdateProductCommand(Product Product) : IRequest<Product>;
