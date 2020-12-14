using System.Runtime.Serialization;

namespace Parking.Domain.Dtos
{
    [DataContract]
    public class CompanyDto
    {
        public CompanyDto()
        {

        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Cnpj { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Telephone { get; set; }
        [DataMember]
        public int NumberOfSpacesForMotorcycles { get; set; }
        [DataMember]
        public int NumberOfSpacesForCars { get; set; }
    }
}
