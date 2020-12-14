using System.Runtime.Serialization;

namespace Parking.Domain.Dtos
{
    [DataContract]
    public class VehicleDto
    {
        public VehicleDto()
        {

        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Brand { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public string Plate { get; set; }
        [DataMember]
        public int Type { get; set; }
    }
}
