using NUnit.Framework;
using Parking.Domain.CommandHandlers;
using Parking.Domain.CommandHandlers.Handlers;
using Parking.Test.Mocks;
using System.Threading.Tasks;

namespace Parking.Test.Handlers.Vehicle
{
    public class VehicleCommandHandlerTest : BaseCommandHandlerTest
    {
        private Domain.Entities.Vehicle validVehicle;
        private VehicleCommandHandler handlerError;
        private VehicleCommandHandler handlerSuccess;
        private RemoveVehicleCommand removeVehicleCommand;

        [SetUp]
        public void Setup()
        {
            validVehicle = new Domain.Entities.Vehicle(1, "honda", "Civic", "prata", "abc1234", 1);
            handlerError = new VehicleCommandHandler(new ErrorVehicleRepository(), new CompanyVehicleCommandHandler(new ErrorCompanyVehicleRepository()) , new ErrorCompanyVehicleRepository());
            handlerSuccess = new VehicleCommandHandler(new SuccessVehicleRepository(), new CompanyVehicleCommandHandler(new SuccessCompanyVehicleRepository()), new SuccessCompanyVehicleRepository());
            removeVehicleCommand = new RemoveVehicleCommand(10);
        }

        [Test]
        public async Task ReturnInsertErrorWhenRepositoryIsWrong()
        {
            validVehicle.Id = 0;
            await BuildInsertCommandHandlerError();
        }

        [Test]
        public async Task ReturnUpdateErrorWhenRepositoryIsWrong() => await BuildUpdateCommandHandlerError();

        [Test]
        public async Task ReturnRemoveErrorWhenIdIsWrong()
        {
            removeVehicleCommand.Id = 0;
            await BuildRemoveCommandHandlerError();
        }

        [Test]
        public async Task ReturnRemoveErrorWhenRepositoryIsWrong() => await BuildRemoveCommandHandlerError();

        [Test]
        public async Task ReturnInsertSuccessWhenRepositoryIsCorrect()
        {
            validVehicle.Id = 0;
            await BuildInsertCommandHandlerSuccess();
        }

        [Test]
        public async Task ReturnUpdateSuccessWhenRepositoryIsCorrect() => await BuildUpdateCommandHandlerSuccess();

        [Test]
        public async Task ReturnRemoveSuccessWhenRepositoryIsCorrect() => await BuildRemoveCommandHandlerSuccess();

        private async Task BuildRemoveCommandHandlerError()
        {
            bool result = await handlerError.Handler(removeVehicleCommand);
            ErrorTests(handlerError.Invalid, result, handlerError.Notifications);
        }
        private async Task BuildInsertCommandHandlerError()
        {
            InsertVehicleCommand saveVehicle = (InsertVehicleCommand)validVehicle;
            int result = await handlerError.Handler(saveVehicle);
            ErrorTests(handlerError.Invalid, result > 0, handlerError.Notifications);
        }

        private async Task BuildUpdateCommandHandlerError()
        {
            UpdateVehicleCommand saveVehicle = (UpdateVehicleCommand)validVehicle;
            bool result = await handlerError.Handler(saveVehicle);
            ErrorTests(handlerError.Invalid, result, handlerError.Notifications);
        }

        private async Task BuildRemoveCommandHandlerSuccess()
        {
            bool result = await handlerSuccess.Handler(removeVehicleCommand);
            SuccessTests(handlerSuccess.Invalid, result, handlerSuccess.Notifications);
        }
        private async Task BuildInsertCommandHandlerSuccess()
        {
            InsertVehicleCommand saveVehicle = (InsertVehicleCommand)validVehicle;
            int result = await handlerSuccess.Handler(saveVehicle);
            SuccessTests(handlerSuccess.Invalid, result > 0, handlerSuccess.Notifications);
        }

        private async Task BuildUpdateCommandHandlerSuccess()
        {
            UpdateVehicleCommand saveVehicle = (UpdateVehicleCommand)validVehicle;
            bool result = await handlerSuccess.Handler(saveVehicle);
            SuccessTests(handlerSuccess.Invalid, result, handlerSuccess.Notifications);
        }
    }
}
