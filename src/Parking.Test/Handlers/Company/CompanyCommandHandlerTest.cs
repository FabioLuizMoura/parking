using NUnit.Framework;
using Parking.Domain.CommandHandlers;
using Parking.Domain.CommandHandlers.Handlers;
using Parking.Test.Mocks;
using System.Threading.Tasks;

namespace Parking.Test.Handlers.Company
{
    public class CompanyCommandHandlerTest : BaseCommandHandlerTest
    {
        private Domain.Entities.Company validEntity;
        private CompanyCommandHandler handlerError;
        private CompanyCommandHandler handlerSuccess;
        private RemoveCompanyCommand removeCommand;

        [SetUp]
        public void Setup()
        {
            validEntity = new Domain.Entities.Company(1, "Estacionamento e cia ltda", "17110897000109", "Rua Dom Pedro II, 518 - Jardim Netinho Prado - Jaú - SP", "1427963861", 43, 20);
            handlerError = new CompanyCommandHandler(new ErrorCompanyRepository(), new ErrorCompanyVehicleRepository());
            handlerSuccess = new CompanyCommandHandler(new SuccessCompanyRepository(), new ErrorCompanyVehicleRepository());
            removeCommand = new RemoveCompanyCommand(10);
        }

        [Test]
        public async Task ReturnUpdateErrorWhenRepositoryIsWrong() => await BuildSaveCommandHandlerError();

        [Test]
        public async Task ReturnRemoveErrorWhenIdIsWrong()
        {
            removeCommand.Id = 0;
            await BuildRemoveCommandHandlerError();
        }

        [Test]
        public async Task ReturnRemoveErrorWhenRepositoryIsWrong() => await BuildRemoveCommandHandlerError();

        [Test]
        public async Task ReturnInsertSuccessWhenRepositoryIsCorrect()
        {
            validEntity.Id = 0;
            await BuildSaveCommandHandlerSuccess();
        }

        [Test]
        public async Task ReturnUpdateSuccessWhenRepositoryIsCorrect() => await BuildSaveCommandHandlerSuccess();

        [Test]
        public async Task ReturnRemoveSuccessWhenRepositoryIsCorrect() => await BuildRemoveCommandHandlerSuccess();

        private async Task BuildRemoveCommandHandlerError()
        {
            bool result = await handlerError.Handler(removeCommand);
            ErrorTests(handlerError.Invalid, result, handlerError.Notifications);
        }
        private async Task BuildSaveCommandHandlerError()
        {
            SaveCompanyCommand saveCommand = (SaveCompanyCommand)validEntity;
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
            SaveCompanyCommand saveCommand = (SaveCompanyCommand)validEntity;
            bool result = await handlerSuccess.Handler(saveCommand);
            SuccessTests(handlerSuccess.Invalid, result, handlerSuccess.Notifications);
        }
    }
}
