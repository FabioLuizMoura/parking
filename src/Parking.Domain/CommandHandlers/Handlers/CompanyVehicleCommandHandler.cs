using Flunt.Notifications;
using Parking.Domain.Entities;
using Parking.Domain.IRespositories;
using System.Threading.Tasks;

namespace Parking.Domain.CommandHandlers.Handlers
{
    public class CompanyVehicleCommandHandler : Notifiable
    {
        private readonly ICompanyVehicleRepository _repository;
        public CompanyVehicleCommandHandler(ICompanyVehicleRepository repository) => _repository = repository;

        public async Task<bool> Handler(SaveCompanyVehicleCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return false;
            }

            CompanyVehicle companyVehicle = command;
            companyVehicle.VehicleEntered();

            if (!await _repository.Insert(companyVehicle))
            {
                AddNotification("", "Erro ao persistir vínculo do veículo com o estabelecimento");
                return false;
            }
            return true;
        }

        public async Task<bool> Handler(UpdateCompanyVehicleCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return false;
            }

            CompanyVehicle companyVehicle = command;
            companyVehicle.VehicleCameOut();
            if (!await _repository.Update(companyVehicle))
            {
                AddNotification("", "Erro ao marcar saída do veículo com o estabelecimento");
                return false;
            }
            return true;
        }

        public async Task<bool> Handler(RemoveCompanyVehicleCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return false;
            }

            var result = await _repository.Delete(command.Id);
            if (!result)
            {
                AddNotification("", "Erro ao deletar o vínculo do veículo com o estabelecimento");
                return false;
            }
            return true;
        }
    }
}
