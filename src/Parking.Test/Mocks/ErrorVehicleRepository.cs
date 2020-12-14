using Parking.Domain.Dtos;
using Parking.Domain.Entities;
using Parking.Domain.IRespositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Test.Mocks
{
    public class ErrorVehicleRepository : IVehicleRepository
    {
        public async Task<bool> Delete(int id)
        {
            await Task.CompletedTask;
            return false;
        }

        public Task<VehicleDto> Get(int id, string plate)
        {
            throw new NotImplementedException();
        }

        public Task<List<VehicleDto>> GetAll(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<VehicleDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<int> Insert(Vehicle vehicle)
        {
            await Task.CompletedTask;
            return -1;
        }

        public async Task<bool> Update(Vehicle vehicle)
        {
            await Task.CompletedTask;
            return false;
        }
    }
}
