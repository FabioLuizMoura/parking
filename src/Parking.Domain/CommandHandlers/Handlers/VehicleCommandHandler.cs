using Flunt.Notifications;
using Parking.Domain.Entities;
using Parking.Domain.IRespositories;
using System.Threading.Tasks;

namespace Parking.Domain.CommandHandlers.Handlers
{
    public class VehicleCommandHandler : Notifiable
    {
        private readonly IVehicleRepository _repository;
        private readonly CompanyVehicleCommandHandler _companyVehicleHandler;
        private readonly ICompanyVehicleRepository _companyVehicleRepository;
        public VehicleCommandHandler(IVehicleRepository repository, CompanyVehicleCommandHandler companyVehicleHandler, ICompanyVehicleRepository companyVehicleRepository)
        {
            _repository = repository;
            _companyVehicleHandler = companyVehicleHandler;
            _companyVehicleRepository = companyVehicleRepository;
        }

        public async Task<int> Handler(InsertVehicleCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return 0;
            }
            Vehicle vehicle = command;
            var id = await _repository.Insert(vehicle);
            if(id <= 0)
            {
                AddNotification("", "Erro ao persistir o veículo");
                return 0;
            }
            if(command.CreateLinkVehicle)
                await SaveCompanyVehicle(id, command.CompanyId);
            return id;
        }

        public async Task<bool> Handler(UpdateVehicleCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return false;
            }
            Vehicle vehicle = command;
            if (!await _repository.Update(vehicle))
            {
                AddNotification("", "Erro ao atualizar o veículo");
                return false;
            }
            return true;
        }

        public async Task<bool> Handler(RemoveVehicleCommand command)
        {
            if (command.Id == 0)
            {
                AddNotification("", "Veículo inexistente");
                return false;
            }
            await _companyVehicleRepository.DeleteByVehicleId(command.Id);
            var result = await _repository.Delete(command.Id);
            if (!result)
            {
                AddNotification("", "Erro ao remover o veículo");
                return false;
            }
            return true;
        }

        private async Task SaveCompanyVehicle(int vehicleId, int companyId)
        {
            await _companyVehicleHandler.Handler(new SaveCompanyVehicleCommand(vehicleId, companyId));
            if (_companyVehicleHandler.Invalid)
            {
                AddNotifications(_companyVehicleHandler);
            }
        }
    }
}
