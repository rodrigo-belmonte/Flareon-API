using ADT.Flareon.Domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Intefaces.Persistence
{
    public interface IProfileRepository : IAsyncRepository<ProfileTable>
    {

    }
}
