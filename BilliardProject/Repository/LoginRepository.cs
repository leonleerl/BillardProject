using BilliardProject.Data;
using BilliardProject.Models;
using BilliardProject.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilliardProject.Repository
{
    public class LoginRepository : ILoginRepository
    {
        public BilliardDbContext DbContext { get; } = new BilliardDbContext();

        public async Task<IEnumerable<User>> GetAll()
        {
            return await DbContext.Users.ToListAsync();
        }

        public async Task<User> Login(string username)
        {
            User user = new User()
            {
                Username = username,
            };
            return await DbContext.Users.FirstOrDefaultAsync(u => u.Username == user.Username);
        }
    }
}