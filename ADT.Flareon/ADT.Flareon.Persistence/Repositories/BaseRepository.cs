using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using ADT.Flareon.Application.Intefaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DocumentModel;

namespace ADT.Flareon.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly IDynamoDBContext _dynamoDBContext;

        public BaseRepository(IDynamoDBContext dynamoDBContext)
        {
            _dynamoDBContext = dynamoDBContext;
        }

        public async Task AddAsync(T entity)
        {
            await _dynamoDBContext.SaveAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _dynamoDBContext.DeleteAsync<T>(id);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dynamoDBContext.LoadAsync<T>(id);
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dynamoDBContext.LoadAsync<T>(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dynamoDBContext.ScanAsync<T>(new List<ScanCondition>()).GetRemainingAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await _dynamoDBContext.SaveAsync(entity);
        }

    }
}
