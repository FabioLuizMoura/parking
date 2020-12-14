using Parking.Domain.CommandHandlers;

namespace Parking.Domain.Entities
{
    public class Company
    {
        public Company(SaveCompanyCommand saveCompany)
        {
            Id = saveCompany.Id;
            Name = saveCompany.Name;
            Cnpj = saveCompany.Cnpj;
            Address = saveCompany.Address;
            Telephone = saveCompany.Telephone;
            NumberOfSpacesForMotorcycles = saveCompany.NumberOfSpacesForMotorcycles;
            NumberOfSpacesForCars = saveCompany.NumberOfSpacesForCars;
        }

        public Company(int id, string name, string cnpj, string address, string telephone, int numberOfSpacesForMotorcycles, int numberOfSpacesForCars)
        {
            Id = id;
            Name = name;
            Cnpj = cnpj;
            Address = address;
            Telephone = telephone;
            NumberOfSpacesForMotorcycles = numberOfSpacesForMotorcycles;
            NumberOfSpacesForCars = numberOfSpacesForCars;
        }

        public Company()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public int NumberOfSpacesForMotorcycles { get; set; }
        public int NumberOfSpacesForCars { get; set; }

        public static implicit operator Company(SaveCompanyCommand saveCompany) => new Company(saveCompany);
    }
}
