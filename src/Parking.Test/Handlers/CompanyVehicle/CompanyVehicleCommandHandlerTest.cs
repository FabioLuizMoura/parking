using NUnit.Framework;
using Parking.Domain.CommandHandlers;
using Parking.Domain.CommandHandlers.Handlers;
using Parking.Test.Mocks;
using System.Threading.Tasks;

namespace Parking.Test.Handlers.CompanyVehicle
{
    public class CompanyVehicleCommandHandlerTest : BaseCommandHandlerTest
    {
        private Domain.Entities.CompanyVehicle validEntity;
        private CompanyVehicleCommandHandler handlerError;
        private CompanyVehicleCommandHandler handlerSuccess;
        private RemoveCompanyVehicleCommand removeCommand;

        [SetUp]
        public void Setup()
        {
            validEntity = new Domain.Entities.CompanyVehicle(123,321);
            handlerError = new CompanyVehicleCommandHandler(new ErrorCompanyVehicleRepository());
            handlerSuccess = new CompanyVehicleCommandHandler(new SuccessCompanyVehicleRepository());
            removeCommand = new RemoveCompanyVehicleCommand(10);
        }

        [Test]
        public async Task ReturnInsertErrorWhenRepositoryIsWrong() => await BuildSaveCommandHandlerError();

        [Test]
        public async Task ReturnUpdateErrorWhenRepositoryIsWrong() => await BuildRemoveCommandHandlerError();

        [Test]
        public async Task ReturnInsertSuccessWhenRepositoryIsCorrect() => await BuildSaveCommandHandlerSuccess();

        [Test]
        public async Task ReturnUpdateSuccessWhenRepositoryIsCorrect() => await BuildRemoveCommandHandlerSuccess();

        private async Task BuildRemoveCommandHandlerError()
        {
            bool result = await handlerError.Handler(removeCommand);
            ErrorTests(handlerError.Invalid, result, handlerError.Notifications);
        }
        private async Task BuildSaveCommandHandlerError()
        {
            SaveCompanyVehicleCommand saveCommand = (SaveCompanyVehicleCommand)validEntity;
            bool result = await handlerError.Handler(saveCommand);
            ErrorTests(handlerError.Invalid, result, handlerError.Notifications);
        }

        private async Task BuildRemoveCommandHandlerSuccess()
        {
            bool result = await handlerSuccess.Handler(removeCommand);
            SuccessTests(handlerSuccess.Invalid, result, handlerSuccess.Notifications);
        }

        private async Task BuildSaveCommandHandlerSuccess()
        {
            SaveCompanyVehicleCommand saveCommand = (SaveCompanyVehicleCommand)validEntity;
            bool result = await handlerSuccess.Handler(saveCommand);
            SuccessTests(handlerSuccess.Invalid, result, handlerSuccess.Notifications);
        }
    }
}
