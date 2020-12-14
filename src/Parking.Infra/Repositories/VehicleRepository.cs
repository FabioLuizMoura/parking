using Dapper;
using Microsoft.Extensions.Configuration;
using Parking.Domain.Dtos;
using Parking.Domain.Entities;
using Parking.Domain.IRespositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.Infra.Repositories
{
    public class VehicleRepository : BaseRepository, IVehicleRepository
    {
        public VehicleRepository(IConfiguration configuration) : base(configuration) {}

        public async Task<bool> Delete(int id)
        {
            var query = "delete from vehicle where id = @id";
            var param = new { id };
            return (await ExecuteAsync(query, param)) > 0;
        }

        public async Task<VehicleDto> Get(int id, string plate)
        {
            var query = "Select * from vehicle where id = @id or plate like @plate";
            var param = new { id, plate };
            return await FindOneAsync<VehicleDto>(query, param);
        }

        public async Task<List<VehicleDto>> GetAll(int companyId)
        {
            var query = "select v.* from vehicle v join companyvehicle cv on cv.vehicleid = v.id where cv.companyId = @companyId and cv.IsActive = 1";
            var param = new { companyId };
            return await FindAllAsync<VehicleDto>(query, param);
        }

        public async Task<List<VehicleDto>> GetAll()
        {
            var query = "select * from vehicle";
            return await FindAllAsync<VehicleDto>(query);
        }

        public async Task<int> Insert(Vehicle vehicle)
        {
            var query = @"insert into vehicle (type, brand, model, color, plate) values (@Type, @Brand, @Model, @Color, @Plate); 
                            SELECT SCOPE_IDENTITY();";
            return await ExecuteScalarAsync(query, vehicle);
        }

        public async Task<bool> Update(Vehicle vehicle)
        {
            var query = "update vehicle set Type = @Type, Brand = @Brand, Model = @Model, Color = @Color, Plate = @Plate where Id = @Id";
            return (await ExecuteAsync(query, vehicle)) > 0;
        }
    }
}
