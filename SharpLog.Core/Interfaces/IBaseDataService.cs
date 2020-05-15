using SharpLog.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SharpLog.Core.Interfaces
{
    public interface IBaseDataService<TModel> where TModel : BaseModel
    {
        IQueryable<TModel> FindAll();

        Task<TModel> FindByIdAsync(string id);

        Task AddAsync(TModel model);

        void Delete(TModel model);

        Task Update(TModel model);
    }
}