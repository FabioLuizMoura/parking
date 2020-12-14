using Flunt.Notifications;
using NUnit.Framework;
using Parking.Domain.CommandHandlers;
using System.Collections.Generic;
using System.Linq;

namespace Parking.Test.Handlers
{
    public class BaseCommandTest<T> where T : BaseCommand
    {
        protected void ExecuteValidationError(T command, string property)
        {
            command.Validate();
            ErrorTests(command.Invalid, command.Notifications, property);
        }

        protected void ErrorTests(bool invalid, IReadOnlyCollection<Notification> notifications, string property)
        {
            Assert.IsTrue(invalid);
            Assert.IsTrue(notifications.Count == 1);
            Assert.IsTrue(notifications.FirstOrDefault().Property.Equals(property));
            Assert.IsFalse(string.IsNullOrEmpty(notifications.FirstOrDefault().Message));
        }

        protected void ExecuteValidationSuccess(T command)
        {
            command.Validate();
            SuccessTests(command.Invalid, command.Notifications);
        }

        protected void SuccessTests(bool invalid, IReadOnlyCollection<Notification> notifications)
        {
            Assert.IsFalse(invalid);
            Assert.IsTrue(notifications.Count == 0);
        }
    }
}
