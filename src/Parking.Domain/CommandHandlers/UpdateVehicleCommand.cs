using Flunt.Validations;
using Parking.Domain.Entities;

namespace Parking.Domain.CommandHandlers
{
    public class UpdateVehicleCommand : BaseCommand
    {
        public UpdateVehicleCommand(Vehicle vehicle)
        {
            Id = vehicle.Id;
            Brand = vehicle.Brand;
            Model = vehicle.Model;
            Color = vehicle.Color;
            Plate = vehicle.Plate;
            Type = vehicle.Type;
        }

        public UpdateVehicleCommand(int id, string brand, string model, string color, string plate, int type)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Color = color;
            Plate = plate;
            Type = type;
        }

        public UpdateVehicleCommand()
        {

        }

        public UpdateVehicleCommand(int id, string brand, string model, string color, string plate, int type, bool createLinkVehicle)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Color = color;
            Plate = plate;
            Type = type;
        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Plate { get; set; }
        public int Type { get; set; }

        public static explicit operator UpdateVehicleCommand(Vehicle vehicle) => new UpdateVehicleCommand(vehicle);

        public override void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Brand, "Brand", "A marca do veículo não pode estar vazia")
                .IsNotNullOrEmpty(Model, "Model", "O modelo do veículo não pode estar vazio")
                .IsNotNullOrEmpty(Color, "Color", "A cor do veículo não pode estar vazia")
                .IsNotNullOrEmpty(Plate, "Plate", "A placa do veículo não pode estar vazia")
                .IsGreaterThan(Type, 0, "Type", "O tipo do veículo não pode estar vazio")
            );

            if (Valid)
            {
                AddNotifications(new Contract()
                    .HasMaxLen(Brand, 70, "Brand", "A marca do veículo deve conter no máximo 70 caracteres")
                    .HasMaxLen(Model, 70, "Model", "O modelo do veículo deve conter no máximo 70 caracteres")
                    .HasMaxLen(Color, 50, "Color", "A cor do veículo deve conter no máximo 70 caracteres")
                    .HasMaxLen(Plate, 7, "Plate", "A placa do veículo deve conter no máximo 70 caracteres")
                );
            }
        }
    }
}
