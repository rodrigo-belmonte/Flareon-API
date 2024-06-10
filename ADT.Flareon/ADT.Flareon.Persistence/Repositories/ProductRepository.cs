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
    public class ProductRepository : BaseRepository<ProductTable>, IProductRepository
    {
        public ProductRepository(IDynamoDBContext dynamoDBContext) : base(dynamoDBContext)
        {
        }
    }
}
