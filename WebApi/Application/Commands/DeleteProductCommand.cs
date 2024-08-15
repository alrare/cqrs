using WebApi.Application.Model;
using MediatR;

namespace WebApi.Application.Commands;

//Utilizar DTO
public record DeleteProductCommand(Product Product) : IRequest<Product>;
