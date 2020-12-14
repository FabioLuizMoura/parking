using Flunt.Notifications;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Parking.Test.Handlers
{
    public class BaseCommandHandlerTest
    {
        protected void ErrorTests(bool invalid, bool result, IReadOnlyCollection<Notification> notifications)
        {
            Assert.IsFalse(result);
            Assert.IsTrue(invalid);
            Assert.IsTrue(notifications.Count == 1);
            Assert.IsFalse(string.IsNullOrEmpty(notifications.FirstOrDefault().Message));
        }

        protected void SuccessTests(bool invalid, bool result, IReadOnlyCollection<Notification> notifications)
        {
            Assert.IsTrue(result);
            Assert.IsFalse(invalid);
            Assert.IsTrue(notifications.Count == 0);
        }
    }
}
