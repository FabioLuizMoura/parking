namespace Parking.Domain.CommandHandlers
{
    public class RemoveVehicleCommand
    {
        public RemoveVehicleCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
