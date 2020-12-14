using Microsoft.AspNetCore.Mvc;
using Parking.Domain.IRespositories;
using Parking.Infra.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleTypeController : BaseController
    {
        private readonly IVehicleTypeRepository _repository;
        public VehicleTypeController(IVehicleTypeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public Task<IActionResult> Get()
        {
            return Response(_repository.GetAll(), new Notification().Notifications);
        }
    }
}
