using Flunt.Notifications;
using Parking.Domain.Entities;
using Parking.Domain.IRespositories;
using System.Threading.Tasks;

namespace Parking.Domain.CommandHandlers.Handlers
{
    public class CompanyCommandHandler : Notifiable
    {
        private readonly ICompanyRepository _repository;
        private readonly ICompanyVehicleRepository _companyVehicleRepository;

        public CompanyCommandHandler(ICompanyRepository repository, ICompanyVehicleRepository companyVehicleRepository)
        {
            _repository = repository;
            _companyVehicleRepository = companyVehicleRepository;
        }

        public async Task<bool> Handler(SaveCompanyCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return false;
            }

            Company customer = command;

            if (customer.Id > 0)
            {
                if (!await _repository.Update(customer))
                {
                    AddNotification("", "Erro ao atualizar o estabelecimento");
                    return false;
                }
            }
            else
                await _repository.Insert(customer);
            return true;
        }

        public async Task<bool> Handler(RemoveCompanyCommand command)
        {
            if (command.Id == 0)
            {
                AddNotification("", "Estabelecimento inexistente");
                return false;
            }

            await _companyVehicleRepository.DeleteByCompanyId(command.Id);
            var result = await _repository.Delete(command.Id);

            if (!result)
            {
                AddNotification("", "Erro ao remover o estabelecimento");
                return false;
            }
            return true;
        }
    }
}
