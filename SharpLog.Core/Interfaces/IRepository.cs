using System;
using System.Threading.Tasks;

namespace SharpLog.Core.Interfaces
{
    internal interface IRepository<T> where T : class
    {
        Task<T> FindAsync(Guid id);

        Task<T> AddAsync(T model);

        Task<T> Update(T model);

        Task Delete(T model);
    }
}