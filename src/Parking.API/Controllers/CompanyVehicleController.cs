using Microsoft.AspNetCore.Mvc;
using Parking.Domain.CommandHandlers;
using Parking.Domain.CommandHandlers.Handlers;
using Parking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyVehicleController : BaseController
    {
        private readonly CompanyVehicleCommandHandler _handler;

        public CompanyVehicleController(CompanyVehicleCommandHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public Task<IActionResult> Post([FromBody] CompanyVehicle companyVehicle)
        {
            var result = _handler.Handler(companyVehicle);
            return Response(result, _handler.Notifications);
        }

        [HttpPatch]
        public Task<IActionResult> Patch([FromBody] CompanyVehicle companyVehicle)
        {
            var result = _handler.Handler((UpdateCompanyVehicleCommand)companyVehicle);
            return Response(result, _handler.Notifications);
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = _handler.Handler(new RemoveCompanyVehicleCommand(id));
            return Response(result, _handler.Notifications);
        }
    }
}
