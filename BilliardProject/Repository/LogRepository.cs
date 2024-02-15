using BilliardProject.Data;
using BilliardProject.Models;
using BilliardProject.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilliardProject.Repository
{
    public class LogRepository : ILogRepository
    {
        public BilliardDbContext DbContext { get; } = new BilliardDbContext();

        public int Add(LogModel logModel)
        {
            DbContext.Add(logModel);
            return DbContext.SaveChanges();
        }

        public async Task<IEnumerable<LogModel>> GetAll()
        {
            return await DbContext.Logs.ToListAsync();
        }
    }
}
