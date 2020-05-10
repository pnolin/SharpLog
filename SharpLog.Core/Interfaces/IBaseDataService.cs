using System.Linq;
using System.Threading.Tasks;

namespace SharpLog.Core.Interfaces
{
    public interface IBaseDataService<TModel>
        where TModel : class
    {
        IQueryable<TModel> FindAll();

        Task<TModel> AddAsync(TModel model);

        void Delete(TModel model);

        Task<TModel> Update(TModel model);
    }
}