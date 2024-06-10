using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using ADT.Flareon.Application.Intefaces.Persistence;
using ADT.Flareon.Domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DocumentModel;

namespace ADT.Flareon.Persistence.Repositories
{
    public class UserRepository : BaseRepository<UserTable>, IUserRepository
    {
        private readonly IDynamoDBContext _dynamoDBContext;

        public UserRepository(IDynamoDBContext dynamoDBContext) : base(dynamoDBContext)
        {
            _dynamoDBContext = dynamoDBContext;
        }
        public async Task<UserTable> Login(string userName)
        {
            var search = _dynamoDBContext.ScanAsync<UserTable>
                (
                new[] {
                    new ScanCondition
                      (
                        nameof(UserTable.Username),
                        ScanOperator.Equal,
                        userName
                      )
                   }
                 );

            var result = await search.GetRemainingAsync();
            if (result.Count == 0)
                return new UserTable();
            return result.FirstOrDefault();
        }
    }
}
