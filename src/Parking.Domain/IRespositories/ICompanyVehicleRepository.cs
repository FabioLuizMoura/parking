using Parking.Domain.Entities;
using System.Threading.Tasks;

namespace Parking.Domain.IRespositories
{
    public interface ICompanyVehicleRepository
    {
        Task<bool> Insert(CompanyVehicle companyVehicle);
        Task<bool> Update(CompanyVehicle companyVehicle);
        Task<bool> DeleteByVehicleId(int vehicleId);
        Task<bool> DeleteByCompanyId(int companyId);
        Task<bool> Delete(int id);
    }
}
