using NUnit.Framework;
using Parking.Domain.CommandHandlers;

namespace Parking.Test.Handlers.CompanyVehicle
{
    public class CompanyVehicleCommandTest : BaseCommandTest<SaveCompanyVehicleCommand>
    {
        private Domain.Entities.CompanyVehicle validCompanyVehicle;
        [SetUp]
        public void Setup()
        {
            validCompanyVehicle = new Domain.Entities.CompanyVehicle(123, 321);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        [TestCase(-100)]
        [TestCase(-1000)]
        public void ReturnErrorWhenVehicleIdIsWrong(int vehicleId)
        {
            validCompanyVehicle.VehicleId = vehicleId;
            BuildCommand("VehicleId");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        [TestCase(-100)]
        [TestCase(-1000)]
        public void ReturnErrorWhenCompanyIdIsWrong(int companyId)
        {
            validCompanyVehicle.CompanyId = companyId;
            BuildCommand("CompanyId");
        }

        [Test]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        public void ReturnSuccessWhenVehicleIdIsCorrect(int vehicleId)
        {
            validCompanyVehicle.VehicleId = vehicleId;
            BuildCommand();
        }

        [Test]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        public void ReturnSuccessWhenCompanyIdIsCorrect(int companyId)
        {
            validCompanyVehicle.CompanyId = companyId;
            BuildCommand();
        }

        private void BuildCommand(string property)
        {
            SaveCompanyVehicleCommand saveCompanyVehicle = (SaveCompanyVehicleCommand)validCompanyVehicle;
            ExecuteValidationError(saveCompanyVehicle, property);
        }

        private void BuildCommand()
        {
            SaveCompanyVehicleCommand saveCompanyVehicle = (SaveCompanyVehicleCommand)validCompanyVehicle;
            ExecuteValidationSuccess(saveCompanyVehicle);
        }
    }
}
