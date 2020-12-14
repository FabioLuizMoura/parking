using Microsoft.Extensions.Configuration;
using Parking.Domain.Dtos;
using Parking.Domain.IRespositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Infra.Repositories
{
    public class VehicleTypeRepository : BaseRepository, IVehicleTypeRepository
    {
        public VehicleTypeRepository(IConfiguration configuration) : base(configuration) {}

        public async Task<List<VehicleTypeDto>> GetAll()
        {
            var query = "select * from vehicletype";
            return await FindAllAsync<VehicleTypeDto>(query);
        }
    }
}
