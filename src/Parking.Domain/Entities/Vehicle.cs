using Parking.Domain.CommandHandlers;

namespace Parking.Domain.Entities
{
    public class Vehicle
    {
        public Vehicle(InsertVehicleCommand insertVehicle)
        {
            Brand = insertVehicle.Brand;
            Model = insertVehicle.Model;
            Color = insertVehicle.Color;
            Plate = insertVehicle.Plate;
            Type = insertVehicle.Type;
        }

        public Vehicle(UpdateVehicleCommand updateVehicle)
        {
            Id = updateVehicle.Id;
            Brand = updateVehicle.Brand;
            Model = updateVehicle.Model;
            Color = updateVehicle.Color;
            Plate = updateVehicle.Plate;
            Type = updateVehicle.Type;
        }

        public Vehicle(int id, string brand, string model, string color, string plate, int type)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Color = color;
            Plate = plate;
            Type = type;
        }

        public Vehicle()
        {

        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Plate { get; set; }
        public int Type { get; set; }

        public static implicit operator Vehicle(InsertVehicleCommand insertVehicle) => new Vehicle(insertVehicle);
        public static implicit operator Vehicle(UpdateVehicleCommand updateVehicle) => new Vehicle(updateVehicle);
    }
}
