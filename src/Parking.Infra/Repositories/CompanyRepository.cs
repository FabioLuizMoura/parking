using Microsoft.Extensions.Configuration;
using Parking.Domain.Dtos;
using Parking.Domain.Entities;
using Parking.Domain.IRespositories;
using System.Threading.Tasks;

namespace Parking.Infra.Repositories
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CompanyRepository(IConfiguration configuration) : base(configuration) {}

        public async Task<bool> Delete(int id)
        {
            var query = "delete from company where id = @id";
            var param = new { id };
            return (await ExecuteAsync(query, param)) > 0;
        }

        public async Task<CompanyDto> Get(int id, string cnpj)
        {
            var query = "Select * from company where id = @id or cnpj like @cnpj";
            var param = new { id, cnpj };
            return await FindOneAsync<CompanyDto>(query, param);
        }

        public async Task<int> Insert(Company company)
        {
            var query = "insert into company (Name, Cnpj, Address, Telephone, NumberOfSpacesForMotorcycles, NumberOfSpacesForCars) values (@Name, @Cnpj, @Address, @Telephone, @NumberOfSpacesForMotorcycles, @NumberOfSpacesForCars)";
            return await ExecuteAsync(query, company);
        }

        public async Task<bool> Update(Company company)
        {
            var query = "update company set Name = @Name, Cnpj = @Cnpj, Address = @Address, Telephone = @Telephone, NumberOfSpacesForMotorcycles = @NumberOfSpacesForMotorcycles, NumberOfSpacesForCars = @NumberOfSpacesForCars where Id = @Id";
            return (await ExecuteAsync(query, company)) > 0;
        }
    }
}
