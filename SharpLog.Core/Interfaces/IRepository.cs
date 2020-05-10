using SharpLog.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SharpLog.Core.Interfaces
{
    public interface IRepository<T> : IQueryable<T> where T : BaseModel
    {
        Task<T> FindByIdAsync(string id);

        Task AddAsync(T model);

        Task Update(T model);

        Task Delete(T model);
    }
}