using Flunt.Notifications;

namespace Parking.Domain.CommandHandlers
{
    public abstract class BaseCommand : Notifiable
    {
        public abstract void Validate();
    }
}
