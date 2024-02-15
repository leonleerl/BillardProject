using BilliardProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BilliardProject.Repository.Interface
{
    public interface ILogRepository
    {
        Task<IEnumerable<LogModel>> GetAll();
        int Add(LogModel logModel);
    }
}
