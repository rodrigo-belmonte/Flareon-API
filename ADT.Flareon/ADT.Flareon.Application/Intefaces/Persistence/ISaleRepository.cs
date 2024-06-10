using ADT.Flareon.Domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Intefaces.Persistence
{
    public interface ISaleRepository : IAsyncRepository<SaleTable>
    {
        Task<IReadOnlyList<SaleTable>> GetFiteredAsync(DateTime startDate, DateTime endDate, string employeeId);
    }
}
