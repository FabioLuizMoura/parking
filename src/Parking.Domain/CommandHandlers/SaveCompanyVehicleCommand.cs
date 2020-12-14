using Flunt.Validations;
using Parking.Domain.Entities;
using System;

namespace Parking.Domain.CommandHandlers
{
    public class SaveCompanyVehicleCommand : BaseCommand
    {
        public SaveCompanyVehicleCommand(int vehicleId, int companyId, DateTime entryDate, DateTime departureDate, bool isActive)
        {
            VehicleId = vehicleId;
            CompanyId = companyId;
            EntryDate = entryDate;
            DepartureDate = departureDate;
            IsActive = isActive;
        }

        public SaveCompanyVehicleCommand(CompanyVehicle companyVehicle)
        {
            VehicleId = companyVehicle.VehicleId;
            CompanyId = companyVehicle.CompanyId;
        }

        public SaveCompanyVehicleCommand(int vehicleId, int companyId)
        {
            VehicleId = vehicleId;
            CompanyId = companyId;
        }

        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int CompanyId { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public bool IsActive { get; set; }

        public static implicit operator SaveCompanyVehicleCommand(CompanyVehicle companyVehicle) => new SaveCompanyVehicleCommand(companyVehicle);

        public override void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(VehicleId, 0, "VehicleId", "O id do veículo não pode estar vazio")
                .IsGreaterThan(CompanyId, 0, "CompanyId", "O id do estabelecimento não pode estar vazio")
            );
        }
    }
}
