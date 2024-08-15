using MinimalApi.Application.Model;
using MediatR;

namespace MinimalApi.Application.Commands;

//Utilizar DTO
public record AddProductCommand(Product Product) : IRequest<Product>;
