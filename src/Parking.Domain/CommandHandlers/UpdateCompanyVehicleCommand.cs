using Flunt.Notifications;
using Flunt.Validations;
using Parking.Domain.Entities;

namespace Parking.Domain.CommandHandlers
{
    public class UpdateCompanyVehicleCommand : Notifiable
    {
        public UpdateCompanyVehicleCommand(int vehicleId, int companyId)
        {
            VehicleId = vehicleId;
            CompanyId = companyId;
        }

        public UpdateCompanyVehicleCommand(CompanyVehicle companyVehicle)
        {
            VehicleId = companyVehicle.VehicleId;
            CompanyId = companyVehicle.CompanyId;
        }

        public int VehicleId { get; set; }
        public int CompanyId { get; set; }

        public static explicit operator UpdateCompanyVehicleCommand(CompanyVehicle companyVehicle) => new UpdateCompanyVehicleCommand(companyVehicle);

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(VehicleId, 0, "VehicleId", "O id do veículo não pode estar vazio")
                .IsGreaterThan(CompanyId, 0, "CompanyId", "O id do estabelecimento não pode estar vazio")
            );
        }
    }
}
