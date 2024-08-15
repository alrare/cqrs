using MediatR;
using WebApi.Infraestructure.Persistence.Context;
using WebApi.Notifications;

namespace WebApi.Application.Handlers;

public class EmailHandler : INotificationHandler<ProductAddedNotifications>
{

    private readonly DataContext _dataContext;
    public EmailHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(ProductAddedNotifications notification, CancellationToken cancellationToken)
    {
        await _dataContext.EventOccured(notification.Product, "Enviar correo electrónico.");
        await Task.CompletedTask;
    }
}

