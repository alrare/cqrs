using MediatR;
using MinimalApi.Infraestructure.Persistence.Context;
using MinimalApi.Notifications;

namespace MinimalApi.Application.Handlers;

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

