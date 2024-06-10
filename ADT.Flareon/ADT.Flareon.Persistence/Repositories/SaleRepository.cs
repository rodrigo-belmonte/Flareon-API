using ADT.Flareon.Application.Intefaces.Persistence;
using ADT.Flareon.Domain.Tables;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Persistence.Repositories
{
    public class SaleRepository : BaseRepository<SaleTable>, ISaleRepository
    {
        private readonly IDynamoDBContext _dynamoDBContext;
        public SaleRepository(IDynamoDBContext dynamoDBContext) : base(dynamoDBContext)
        {
            _dynamoDBContext = dynamoDBContext;
        }

        public async Task<IReadOnlyList<SaleTable>> GetFiteredAsync(DateTime startDate, DateTime endDate, string employeeId)
        {
            var conditions = new List<ScanCondition>{
                    new ScanCondition
                      (
                        "DtSale",
                        ScanOperator.Between,startDate, endDate
                      )
                   };

            if (employeeId != "")
            {
                conditions.Add(new ScanCondition
                      (
                        "EmployeeId",
                        ScanOperator.Equal,
                        employeeId
                      ));
            }

            var search = _dynamoDBContext.ScanAsync<SaleTable>(conditions);
               
            

            var result = await search.GetRemainingAsync();

            if (result.Count == 0)
                return new List<SaleTable>();
            return result;
        }
    }
}
