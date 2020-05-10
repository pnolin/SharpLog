using MongoDB.Driver;
using SharpLog.Core.Interfaces;
using SharpLog.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SharpLog.MongoDB.Infrastructure.Repositories
{
    public class MongoDBRepository<T> : IRepository<T> where T : BaseModel
    {
        private readonly IMongoCollection<T> _collection;

        public MongoDBRepository(ISettingsService settingsService)
        {
            var client = new MongoClient(settingsService.MongoDBSettings.ConnectionString);
            var database = client.GetDatabase(settingsService.MongoDBSettings.DatabaseName);

            _collection = database.GetCollection<T>(settingsService.MongoDBSettings.CollectionName);
        }

        public Task AddAsync(T modelToAdd) =>
            _collection.InsertOneAsync(modelToAdd);

        public Task Delete(T modelToDelete) =>
            _collection.DeleteOneAsync(model => model.Id == modelToDelete.Id);

        public Task<T> FindByIdAsync(string id) =>
            _collection.Find(model => model.Id == id).FirstOrDefaultAsync();

        public Task Update(T modelToUpdate) =>
            _collection.ReplaceOneAsync(model => model.Id == modelToUpdate.Id, modelToUpdate);

        public Type ElementType => GetQueryable().ElementType;

        public Expression Expression => GetQueryable().Expression;

        public IQueryProvider Provider => GetQueryable().Provider;

        public IEnumerator<T> GetEnumerator() => GetQueryable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private IQueryable<T> GetQueryable()
            => _collection.AsQueryable();
    }
}