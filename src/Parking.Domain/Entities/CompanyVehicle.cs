using Parking.Domain.CommandHandlers;
using System;

namespace Parking.Domain.Entities
{
    public class CompanyVehicle
    {
        public CompanyVehicle() { }

        public CompanyVehicle(UpdateCompanyVehicleCommand updateCompanyVehicle)
        {
            VehicleId = updateCompanyVehicle.VehicleId;
            CompanyId = updateCompanyVehicle.CompanyId;
        }

        public CompanyVehicle(SaveCompanyVehicleCommand saveCompanyVehicle)
        {
            Id = saveCompanyVehicle.Id;
            VehicleId = saveCompanyVehicle.VehicleId;
            CompanyId = saveCompanyVehicle.CompanyId;
            EntryDate = saveCompanyVehicle.EntryDate;
            DepartureDate = saveCompanyVehicle.DepartureDate;
            IsActive = saveCompanyVehicle.IsActive;
        }

        public CompanyVehicle(int vehicleId, int companyId)
        {
            VehicleId = vehicleId;
            CompanyId = companyId;
        }

        public static implicit operator CompanyVehicle(SaveCompanyVehicleCommand saveCompanyVehicle) => new CompanyVehicle(saveCompanyVehicle);
        public static implicit operator CompanyVehicle(UpdateCompanyVehicleCommand updateCompanyVehicle) => new CompanyVehicle(updateCompanyVehicle);

        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int CompanyId { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public bool IsActive { get; set; }

        public void VehicleEntered()
        {
            EntryDate = DateTime.Now;
            IsActive = true;
        }

        public void VehicleCameOut()
        {
            DepartureDate = DateTime.Now;
            IsActive = false;
        }
    }
}
