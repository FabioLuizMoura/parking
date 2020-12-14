using Parking.Domain.Dtos;
using Parking.Domain.Entities;
using Parking.Domain.IRespositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Test.Mocks
{
    public class SuccessCompanyRepository : ICompanyRepository
    {
        public async Task<bool> Delete(int id)
        {
            await Task.CompletedTask;
            return true;
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
            return true;
        }
    }
}
