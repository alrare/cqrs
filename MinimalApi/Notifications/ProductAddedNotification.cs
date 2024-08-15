using MediatR;
using MinimalApi.Application.Model;

namespace MinimalApi.Notifications
{
    public record ProductAddedNotifications(Product Product) : INotification
    {

    }

}
