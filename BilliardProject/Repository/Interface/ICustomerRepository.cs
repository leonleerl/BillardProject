using BilliardProject.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BilliardProject.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerModel>> GetAll();
        int Add(CustomerModel model);
        int Update(CustomerModel model);
        int Delete(CustomerModel model);
        Task<CustomerModel> GetById(Guid id);
    }
}
