using Flunt.Validations;
using Parking.Domain.Entities;

namespace Parking.Domain.CommandHandlers
{
    public class SaveCompanyCommand : BaseCommand
    {
        public SaveCompanyCommand(Company company)
        {
            Id = company.Id;
            Name = company.Name;
            Cnpj = company.Cnpj;
            Address = company.Address;
            Telephone = company.Telephone;
            NumberOfSpacesForMotorcycles = company.NumberOfSpacesForMotorcycles;
            NumberOfSpacesForCars = company.NumberOfSpacesForCars;
        }

        public SaveCompanyCommand(int id, string name, string cnpj, string address, string telephone, int numberOfSpacesForMotorcycles, int numberOfSpacesForCars)
        {
            Id = id;
            Name = name;
            Cnpj = cnpj;
            Address = address;
            Telephone = telephone;
            NumberOfSpacesForMotorcycles = numberOfSpacesForMotorcycles;
            NumberOfSpacesForCars = numberOfSpacesForCars;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public int NumberOfSpacesForMotorcycles { get; set; }
        public int NumberOfSpacesForCars { get; set; }

        public static implicit operator SaveCompanyCommand(Company company) => new SaveCompanyCommand(company);

        public override void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Name, "Name", "O nome do estabelecimento não pode estar vazio")
                .IsNotNullOrEmpty(Cnpj, "Cnpj", "O cnpj não pode estar vazio")
                .HasExactLengthIfNotNullOrEmpty(Cnpj, 14, "Cnpj", "O Cnpj deve conter o total de 14 caracteres")
                .IsNotNullOrEmpty(Address, "Address", "O endereço não pode estar vazio")
                .HasMinLen(Telephone, 8, "Telephone", "O telefone não pode ter menos que 8 caracteres")
                .IsGreaterThan(NumberOfSpacesForMotorcycles, 0, "NumberOfSpacesForMotorcycles", "A quantidade de vagas para motos não pode estar vazia")
                .IsGreaterThan(NumberOfSpacesForCars, 0, "NumberOfSpacesForCars", "A quantidade de vagas para carros não pode estar vazia")
            );

            if (Valid)
            {
                AddNotifications(new Contract()
                    .HasMaxLen(Name, 70, "Name", "O Nome deve conter no máximo 70 caracteres")
                    .HasMaxLen(Address, 70, "Address", "O endereço deve conter no máximo 70 caracteres")
                    .HasMaxLen(Telephone, 11, "Telephone", "O telefone deve conter no máximo 11 caracteres")
                );
            }
        }

        public void ResetCustomerId() => Id = 0;
    }
}
