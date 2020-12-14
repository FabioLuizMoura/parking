namespace Parking.Domain.CommandHandlers
{
    public class RemoveCompanyCommand
    {
        public RemoveCompanyCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
