using Parking.Domain.Entities;
using Parking.Domain.IRespositories;
using System.Threading.Tasks;

namespace Parking.Test.Mocks
{
    public class SuccessCompanyVehicleRepository : ICompanyVehicleRepository
    {
        public async Task<bool> Delete(int id)
        {
            await Task.CompletedTask;
            return true;
        }

        public async Task<bool> DeleteByCompanyId(int companyId)
        {
            await Task.CompletedTask;
            return true;
        }

        public async Task<bool> DeleteByVehicleId(int vehicleId)
        {
            await Task.CompletedTask;
            return true;
        }

        public async Task<bool> Insert(CompanyVehicle companyVehicle)
        {
            await Task.CompletedTask;
            return true;
        }

        public async Task<bool> Update(CompanyVehicle companyVehicle)
        {
            await Task.CompletedTask;
            return true;
        }
    }
}
