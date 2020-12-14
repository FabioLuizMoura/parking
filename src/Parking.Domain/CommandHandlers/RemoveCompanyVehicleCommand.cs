using Flunt.Notifications;
using Flunt.Validations;

namespace Parking.Domain.CommandHandlers
{
    public class RemoveCompanyVehicleCommand : Notifiable
    {
        public RemoveCompanyVehicleCommand(int id) => Id = id;
        public int Id { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(Id, 0, "Id", "O id do vínculo do veículo com o estabelecimento não pode estar vazio")
            );
        }
    }
}
