using Parking.Domain.Dtos;
using Parking.Domain.Entities;
using Parking.Domain.IRespositories;
using System;
using System.Threading.Tasks;

namespace Parking.Test.Mocks
{
    public class ErrorCompanyRepository : ICompanyRepository
    {
        public async Task<bool> Delete(int id)
        {
            await Task.CompletedTask;
            return false;
        }

        public Task<CompanyDto> Get(int id, string cnpj)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Insert(Company company)
        {
            await Task.CompletedTask;
            return 1;
        }

        public async Task<bool> Update(Company company)
        {
            await Task.CompletedTask;
            return false;
        }
    }
}
