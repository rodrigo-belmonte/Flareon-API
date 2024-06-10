using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using ADT.Flareon.Application.Intefaces.Persistence;
using ADT.Flareon.Domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<OrderTable>, IOrderRepository
    {
        private readonly IDynamoDBContext _dynamoDBContext;

        public OrderRepository(IDynamoDBContext dynamoDBContext) : base(dynamoDBContext)
        {
            _dynamoDBContext = dynamoDBContext;
        }
        public async Task AddOrderAsync(OrderTable entity)
        {
            await _dynamoDBContext.SaveAsync(entity);
        }
    }
}
