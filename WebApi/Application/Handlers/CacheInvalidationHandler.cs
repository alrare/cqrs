using MediatR;
using WebApi.Infraestructure.Persistence.Context;
using WebApi.Notifications;

namespace WebApi.Application.Handlers;

public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotifications>
{
    private readonly DataContext _context;
    public CacheInvalidationHandler(DataContext context)
    {
        _context = context;
    }

    public async Task Handle(ProductAddedNotifications notification, CancellationToken cancellationToken)
    {
        await _context.EventOccured(notification.Product, "Cache invalida.");
        await Task.CompletedTask;
    }
}

