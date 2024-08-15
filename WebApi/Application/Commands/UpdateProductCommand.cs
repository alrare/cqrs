using WebApi.Application.Model;
using MediatR;

namespace WebApi.Application.Commands;

//Utilizar DTO
public record UpdateProductCommand(Product Product) : IRequest<Product>;
