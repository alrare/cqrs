using WebApi.Application.Model;
using MediatR;

namespace WebApi.Application.Commands;

//Utilizar DTO
public record AddProductCommand(Product Product) : IRequest<Product>;
