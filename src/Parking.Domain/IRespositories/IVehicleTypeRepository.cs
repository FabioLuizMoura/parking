using Parking.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Domain.IRespositories
{
    public interface IVehicleTypeRepository
    {
        Task<List<VehicleTypeDto>> GetAll();
    }
}
