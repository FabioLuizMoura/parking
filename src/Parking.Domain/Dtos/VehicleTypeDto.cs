using System.Runtime.Serialization;

namespace Parking.Domain.Dtos
{
    [DataContract]
    public class VehicleTypeDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
