using SharpLog.Core.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace SharpLog.Core.Services
{
    public abstract class BaseDataService<TModel> : IBaseDataService<TModel> where TModel : class
    {
        protected readonly IRepository<TModel> _repository;

        protected BaseDataService(
            IRepository<TModel> repository
        )
        {
            _repository = repository;
        }

        public Task<TModel> AddAsync(TModel model) =>
            _repository.AddAsync(model);

        public void Delete(TModel model)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<TModel> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<TModel> Update(TModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}