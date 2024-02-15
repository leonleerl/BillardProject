using BilliardProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BilliardProject.Repository.Interface
{
    public interface ILoginRepository
    {
        Task<User> Login(string username);
        Task<IEnumerable<User>> GetAll();
    }
}
