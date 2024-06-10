using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Domain.Common
{
    public class AuditableTable
    {
        [DynamoDBHashKey]
        public Guid Id { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtLastUpdate { get; set; }
        public Guid LastUserUpdated { get; set; }

    }
}
