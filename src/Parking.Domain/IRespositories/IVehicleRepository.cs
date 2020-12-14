using Parking.Domain.Dtos;
using Parking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Domain.IRespositories
{
    public interface IVehicleRepository
    {
        Task<VehicleDto> Get(int id, string plate);
        Task<List<VehicleDto>> GetAll(int companyId);
        Task<List<VehicleDto>> GetAll();
        Task<int> Insert(Vehicle vehicle);
        Task<bool> Update(Vehicle vehicle);
        Task<bool> Delete(int id);
    }
}
