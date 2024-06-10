using ADT.Flareon.Application.Intefaces.Persistence;
using ADT.Flareon.Domain.Tables;
using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Persistence.Repositories
{
    public class OrderLastInsertedIdTableRepository : BaseRepository<OrderLastInsertedIdTable>, IOrderLastInsertedIdTableRepository
    {
        public OrderLastInsertedIdTableRepository(IDynamoDBContext dynamoDBContext) : base(dynamoDBContext)
        {
        }
    }
}
