using MinimalApi.Application.Model;
using MediatR;

namespace MinimalApi.Application.Commands;

//Utilizar DTO
public record DeleteProductCommand(Product Product) : IRequest<Product>;
