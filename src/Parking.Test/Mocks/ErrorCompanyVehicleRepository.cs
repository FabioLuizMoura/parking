using Parking.Domain.Entities;
using Parking.Domain.IRespositories;
using System.Threading.Tasks;

namespace Parking.Test.Mocks
{
    public class ErrorCompanyVehicleRepository : ICompanyVehicleRepository
    {
        public async Task<bool> Delete(int id)
        {
            await Task.CompletedTask;
            return false;
        }

        public async Task<bool> DeleteByCompanyId(int companyId)
        {
            await Task.CompletedTask;
            return false;
        }

        public async Task<bool> DeleteByVehicleId(int vehicleId)
        {
            await Task.CompletedTask;
            return false;
        }

        public async Task<bool> Insert(CompanyVehicle companyVehicle)
        {
            await Task.CompletedTask;
            return false;
        }

        public async Task<bool> Update(CompanyVehicle companyVehicle)
        {
            await Task.CompletedTask;
            return false;
        }
    }
}
