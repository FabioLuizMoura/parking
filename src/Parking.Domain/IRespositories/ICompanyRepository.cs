using Parking.Domain.Dtos;
using Parking.Domain.Entities;
using System.Threading.Tasks;

namespace Parking.Domain.IRespositories
{
    public interface ICompanyRepository
    {
        Task<CompanyDto> Get(int id, string cnpj);
        Task<int> Insert(Company company);
        Task<bool> Update(Company company);
        Task<bool> Delete(int id);
    }
}
