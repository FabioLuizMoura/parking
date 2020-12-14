using NUnit.Framework;
using Parking.Domain.CommandHandlers;

namespace Parking.Test.Handlers.Vehicle
{
    public class VehicleCommandTest : BaseCommandTest<InsertVehicleCommand>
    {
        private Domain.Entities.Vehicle validVehicle;
        [SetUp]
        public void Setup()
        {
            validVehicle = new Domain.Entities.Vehicle(1, "honda", "Civic", "prata", "abc1234", 1);
        }

        [Test]
        [TestCase("")]
        [TestCase("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb")]
        public void ReturnInsertErrorWhenBrandIsWrong(string brand)
        {
            validVehicle.Brand = brand;
            BuildCommandInsert("Brand");
        }

        [Test]
        [TestCase("")]
        [TestCase("mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm")]
        public void ReturnInsertErrorWhenModelIsWrong(string model)
        {
            validVehicle.Model = model;
            BuildCommandInsert("Model");
        }

        [Test]
        [TestCase("")]
        [TestCase("ccccccccccccccccccccccccccccccccccccccccccccccccccc")]
        public void ReturnInsertErrorWhenColorIsWrong(string color)
        {
            validVehicle.Color = color;
            BuildCommandInsert("Color");
        }

        [Test]
        [TestCase("")]
        [TestCase("abcd1234")]
        public void ReturnInsertErrorWhenPlateIsWrong(string plate)
        {
            validVehicle.Plate = plate;
            BuildCommandInsert("Plate");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-2)]
        public void ReturnInsertErrorWhenTypeIsWrong(int type)
        {
            validVehicle.Type = type;
            BuildCommandInsert("Type");
        }

        [Test]
        [TestCase("b")]
        [TestCase("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb")]
        public void ReturnInsertSuccessWhenBrandIsCorrect(string brand)
        {
            validVehicle.Brand = brand;
            BuildCommandInsert();
        }

        [Test]
        [TestCase("m")]
        [TestCase("mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm")]
        public void ReturnInsertSuccessWhenModelIsCorrect(string model)
        {
            validVehicle.Model = model;
            BuildCommandInsert();
        }

        [Test]
        [TestCase("c")]
        [TestCase("cccccccccccccccccccccccccccccccccccccccccccccccccc")]
        public void ReturnInsertSuccessWhenColorIsCorrect(string color)
        {
            validVehicle.Color = color;
            BuildCommandInsert();
        }

        [Test]
        [TestCase("a")]
        [TestCase("abc1234")]
        public void ReturnInsertSuccessWhenPlateIsCorrect(string plate)
        {
            validVehicle.Plate = plate;
            BuildCommandInsert();
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void ReturnInsertSuccessWhenTypeIsCorrect(int type)
        {
            validVehicle.Type = type;
            BuildCommandInsert();
        }

        [Test]
        [TestCase("")]
        [TestCase("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb")]
        public void ReturnUpdateErrorWhenBrandIsWrong(string brand)
        {
            validVehicle.Brand = brand;
            BuildCommandUpdate("Brand");
        }

        [Test]
        [TestCase("")]
        [TestCase("mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm")]
        public void ReturnUpdateErrorWhenModelIsWrong(string model)
        {
            validVehicle.Model = model;
            BuildCommandUpdate("Model");
        }

        [Test]
        [TestCase("")]
        [TestCase("ccccccccccccccccccccccccccccccccccccccccccccccccccc")]
        public void ReturnUpdateErrorWhenColorIsWrong(string color)
        {
            validVehicle.Color = color;
            BuildCommandUpdate("Color");
        }

        [Test]
        [TestCase("")]
        [TestCase("abcd1234")]
        public void ReturnUpdateErrorWhenPlateIsWrong(string plate)
        {
            validVehicle.Plate = plate;
            BuildCommandUpdate("Plate");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-2)]
        public void ReturnUpdateErrorWhenTypeIsWrong(int type)
        {
            validVehicle.Type = type;
            BuildCommandUpdate("Type");
        }

        [Test]
        [TestCase("b")]
        [TestCase("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb")]
        public void ReturnUpdateSuccessWhenBrandIsCorrect(string brand)
        {
            validVehicle.Brand = brand;
            BuildCommandUpdate();
        }

        [Test]
        [TestCase("m")]
        [TestCase("mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm")]
        public void ReturnUpdateSuccessWhenModelIsCorrect(string model)
        {
            validVehicle.Model = model;
            BuildCommandUpdate();
        }

        [Test]
        [TestCase("c")]
        [TestCase("cccccccccccccccccccccccccccccccccccccccccccccccccc")]
        public void ReturnUpdateSuccessWhenColorIsCorrect(string color)
        {
            validVehicle.Color = color;
            BuildCommandUpdate();
        }

        [Test]
        [TestCase("a")]
        [TestCase("abc1234")]
        public void ReturnUpdateSuccessWhenPlateIsCorrect(string plate)
        {
            validVehicle.Plate = plate;
            BuildCommandUpdate();
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void ReturnUpdateSuccessWhenTypeIsCorrect(int type)
        {
            validVehicle.Type = type;
            BuildCommandUpdate();
        }

        private void BuildCommandInsert(string property)
        {
            InsertVehicleCommand saveVehicle = (InsertVehicleCommand)validVehicle;
            ExecuteValidationError(saveVehicle, property);
        }

        private void BuildCommandInsert()
        {
            InsertVehicleCommand saveVehicle = (InsertVehicleCommand)validVehicle;
            ExecuteValidationSuccess(saveVehicle);
        }

        private void BuildCommandUpdate(string property)
        {
            InsertVehicleCommand saveVehicle = (InsertVehicleCommand)validVehicle;
            ExecuteValidationError(saveVehicle, property);
        }

        private void BuildCommandUpdate()
        {
            InsertVehicleCommand saveVehicle = (InsertVehicleCommand)validVehicle;
            ExecuteValidationSuccess(saveVehicle);
        }
    }
}
