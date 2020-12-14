using Microsoft.AspNetCore.Mvc;
using Parking.Domain.CommandHandlers;
using Parking.Domain.CommandHandlers.Handlers;
using Parking.Domain.Entities;
using Parking.Domain.IRespositories;
using Parking.Infra.Config;
using System.Threading.Tasks;

namespace Parking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : BaseController
    {
        private readonly CompanyCommandHandler _handler;
        private readonly ICompanyRepository _repository;

        public CompanyController(CompanyCommandHandler handler, ICompanyRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpGet]
        public Task<IActionResult> Get([FromQuery] int id, [FromQuery] string cnpj)
        {
            return Response(_repository.Get(id, cnpj), new Notification().Notifications);
        }

        [HttpPost]
        public Task<IActionResult> Post([FromBody] Company company)
        {
            SaveCompanyCommand companyCommand = company;
            companyCommand.ResetCustomerId();
            var result = _handler.Handler(companyCommand);
            return Response(result, _handler.Notifications);
        }

        [HttpPut]
        public Task<IActionResult> Put([FromBody] Company company)
        {
            var result = _handler.Handler(company);
            return Response(result, _handler.Notifications);
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = _handler.Handler(new RemoveCompanyCommand(id));
            return Response(result, _handler.Notifications);
        }

        [HttpPost("{id}/vehicle")]
        public Task<IActionResult> Post([FromRoute] int id, [FromBody] Vehicle vehicle, [FromServices] VehicleCommandHandler vehicleHandler)
        {
            InsertVehicleCommand vehicleCommand = vehicle;
            vehicleCommand.CreateVehicleCompany(id);
            var result = vehicleHandler.Handler(vehicleCommand);
            return Response(result, vehicleHandler.Notifications);
        }

        [HttpGet("{id}/vehicle")]
        public Task<IActionResult> Get([FromRoute] int id, [FromServices] IVehicleRepository vehicleRepository)
        {
            return Response(vehicleRepository.GetAll(id), new Notification().Notifications);
        }
    }
}
