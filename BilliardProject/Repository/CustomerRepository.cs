using BilliardProject.Data;
using BilliardProject.Models;
using BilliardProject.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilliardProject.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public BilliardDbContext DbContext { get; } = new BilliardDbContext();

        public async Task<IEnumerable<CustomerModel>> GetAll()
        {
            return await DbContext.Customers.ToListAsync();
        }

        public int Add(CustomerModel model)
        {
            DbContext.Customers.Add(model);
            return DbContext.SaveChanges();
        }

        public int Update(CustomerModel model)
        {
            DbContext.Customers.Update(model);
            return DbContext.SaveChanges();
        }

        public async Task<CustomerModel> GetById(Guid id)
        {
            return await DbContext.Customers.FirstOrDefaultAsync(p => p.Id == id);
        }
        public int Delete(CustomerModel model)
        {
            CustomerModel c = DbContext.Customers.FirstOrDefault(p => p.Id == model.Id);
            DbContext.Customers.Remove(c);
            return DbContext.SaveChanges();
        }
    }
}









