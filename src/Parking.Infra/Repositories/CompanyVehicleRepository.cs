using Microsoft.Extensions.Configuration;
using Parking.Domain.Entities;
using Parking.Domain.IRespositories;
using System.Threading.Tasks;

namespace Parking.Infra.Repositories
{
    public class CompanyVehicleRepository : BaseRepository, ICompanyVehicleRepository
    {
        public CompanyVehicleRepository(IConfiguration configuration) : base(configuration) {}

        public async Task<bool> Insert(CompanyVehicle companyVehicle)
        {
            var query = "insert into companyvehicle (VehicleId, CompanyId, EntryDate, IsActive) values (@VehicleId, @CompanyId, @EntryDate, @IsActive)";
            return await Execute(query, companyVehicle);
        }

        public async Task<bool> Update(CompanyVehicle companyVehicle)
        {
            var query = "update companyvehicle set DepartureDate = @DepartureDate, IsActive = @IsActive where VehicleId = @VehicleId and CompanyId = @CompanyId and IsActive = 1";
            return await Execute(query, companyVehicle);
        }

        public async Task<bool> DeleteByVehicleId(int vehicleId)
        {
            var query = "delete from companyvehicle where VehicleId = @VehicleId";
            var param = new { VehicleId = vehicleId };
            return await Execute(query, param);
        }

        public async Task<bool> DeleteByCompanyId(int companyId)
        {
            var query = "delete from companyvehicle where CompanyId = @CompanyId";
            var param = new { CompanyId = companyId };
            return await Execute(query, param);
        }

        public async Task<bool> Delete(int id)
        {
            var query = "delete from companyvehicle where Id = @Id";
            var param = new { Id = id };
            return await Execute(query, param);
        }

        private async Task<bool> Execute<T>(string query, T companyVehicle) => await ExecuteAsync(query, companyVehicle) > 0;
    }
}
