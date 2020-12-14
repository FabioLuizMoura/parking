using NUnit.Framework;
using Parking.Domain.CommandHandlers;

namespace Parking.Test.Handlers.Company
{
    public class CompanyCommandTest : BaseCommandTest<SaveCompanyCommand>
    {
        private Domain.Entities.Company validCompany;
        [SetUp]
        public void Setup()
        {
            validCompany = new Domain.Entities.Company(1, "Estacionamento e cia ltda", "17110897000109", "Rua Dom Pedro II, 518 - Jardim Netinho Prado - Jaú - SP", "1427963861", 43, 20);
        }

        [Test]
        [TestCase("")]
        [TestCase("nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn")]
        public void ReturnErrorWhenNameIsWrong(string name)
        {
            validCompany.Name = name;
            BuildCommand("Name");
        }

        [Test]
        [TestCase("")]
        [TestCase("c")]
        [TestCase("ccc")]
        [TestCase("cccccc")]
        [TestCase("ccccccccc")]
        [TestCase("cccccccccccc")]
        [TestCase("ccccccccccccccc")]
        public void ReturnErrorWhenCnpjIsWrong(string cnpj)
        {
            validCompany.Cnpj = cnpj;
            BuildCommand("Cnpj");
        }

        [Test]
        [TestCase("")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void ReturnErrorWhenAddressIsWrong(string address)
        {
            validCompany.Address = address;
            BuildCommand("Address");
        }

        [Test]
        [TestCase("")]
        [TestCase("523")]
        [TestCase("54523")]
        [TestCase("7654523")]
        [TestCase("111987654523")]
        public void ReturnErrorWhenTelephoneIsWrong(string telephone)
        {
            validCompany.Telephone = telephone;
            BuildCommand("Telephone");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        [TestCase(-100)]
        [TestCase(-1000)]
        public void ReturnErrorWhenNumberOfSpacesForMotorcyclesIsWrong(int numberOfSpacesForMotorcycles)
        {
            validCompany.NumberOfSpacesForMotorcycles = numberOfSpacesForMotorcycles;
            BuildCommand("NumberOfSpacesForMotorcycles");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-20)]
        [TestCase(-200)]
        [TestCase(-2000)]
        public void ReturnErrorWhenNumberOfSpacesForCarsIsWrong(int numberOfSpacesForCars)
        {
            validCompany.NumberOfSpacesForCars = numberOfSpacesForCars;
            BuildCommand("NumberOfSpacesForCars");
        }

        [Test]
        [TestCase("n")]
        [TestCase("nnnnnnnnnnnnnnnnnnnnnnnnnnnnnn")]
        [TestCase("nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn")]
        public void ReturnSuccessWhenNameIsCorrect(string name)
        {
            validCompany.Name = name;
            BuildCommand();
        }

        [Test]
        [TestCase("17110897000109")]
        public void ReturnSuccessWhenCnpjIsCorrect(string cnpj)
        {
            validCompany.Cnpj = cnpj;
            BuildCommand();
        }

        [Test]
        [TestCase("a")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void ReturnSuccessWhenAddressIsCorrect(string address)
        {
            validCompany.Address = address;
            BuildCommand();
        }

        [Test]
        [TestCase("87654523")]
        [TestCase("987654523")]
        [TestCase("11987654523")]
        public void ReturnSuccessWhenTelephoneIsCorrect(string telephone)
        {
            validCompany.Telephone = telephone;
            BuildCommand();
        }

        [Test]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        public void ReturnSuccessWhenNumberOfSpacesForMotorcyclesIsCorrect(int numberOfSpacesForMotorcycles)
        {
            validCompany.NumberOfSpacesForMotorcycles = numberOfSpacesForMotorcycles;
            BuildCommand();
        }

        [Test]
        [TestCase(20)]
        [TestCase(200)]
        [TestCase(2000)]
        public void ReturnSuccessWhenNumberOfSpacesForCarsIsCorrect(int numberOfSpacesForCars)
        {
            validCompany.NumberOfSpacesForCars = numberOfSpacesForCars;
            BuildCommand();
        }

        private void BuildCommand(string property)
        {
            SaveCompanyCommand saveCompany = (SaveCompanyCommand)validCompany;
            ExecuteValidationError(saveCompany, property);
        }

        private void BuildCommand()
        {
            SaveCompanyCommand saveCompany = (SaveCompanyCommand)validCompany;
            ExecuteValidationSuccess(saveCompany);
        }
    }
}
