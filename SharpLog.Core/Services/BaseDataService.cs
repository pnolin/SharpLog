using SharpLog.Core.Interfaces;
using SharpLog.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SharpLog.Core.Services
{
    public abstract class BaseDataService<TModel> : IBaseDataService<TModel> where TModel : BaseModel
    {
        protected readonly IRepository<TModel> _repository;

        protected BaseDataService(
            IRepository<TModel> repository
        )
        {
            _repository = repository;
        }

        public IQueryable<TModel> FindAll() => _repository;

        public Task<TModel> FindByIdAsync(string id) =>
            _repository.FindByIdAsync(id);

        public Task AddAsync(TModel model) =>
            _repository.AddAsync(model);

        public void Delete(TModel model) =>
            _repository.Delete(model);

        public Task Update(TModel model) =>
            _repository.Update(model);
    }
}