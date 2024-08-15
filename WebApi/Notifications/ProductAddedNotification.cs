using MediatR;
using WebApi.Application.Model;

namespace WebApi.Notifications
{
    public record ProductAddedNotifications(Product Product) : INotification
    {

    }

}
