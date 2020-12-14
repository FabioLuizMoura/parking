using Microsoft.AspNetCore.Mvc;
using Parking.Domain.CommandHandlers;
using Parking.Domain.CommandHandlers.Handlers;
using Parking.Domain.IRespositories;
using Parking.Infra.Config;
using System.Threading.Tasks;

namespace Parking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : BaseController
    {
        private readonly VehicleCommandHandler _handler;
        private readonly IVehicleRepository _repository;

        public VehicleController(VehicleCommandHandler handler, IVehicleRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpGet]
        public Task<IActionResult> Get([FromQuery] int id, [FromQuery] string plate)
        {
            if (id > 0 || !string.IsNullOrEmpty(plate))
                return Response(_repository.Get(id, plate), new Notification().Notifications);
            else
                return Response(_repository.GetAll(), new Notification().Notifications);
        }

        [HttpPost]
        public Task<IActionResult> Post([FromBody] InsertVehicleCommand vehicleCommand)
        {
            var result = _handler.Handler(vehicleCommand);
            return Response(result, _handler.Notifications);
        }

        [HttpPut]
        public Task<IActionResult> Put([FromBody] UpdateVehicleCommand vehicleCommand)
        {
            var result = _handler.Handler(vehicleCommand);
            return Response(result, _handler.Notifications);
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = _handler.Handler(new RemoveVehicleCommand(id));
            return Response(result, _handler.Notifications);
        }
    }
}
