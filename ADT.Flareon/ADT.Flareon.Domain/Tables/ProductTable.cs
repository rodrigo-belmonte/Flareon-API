using Amazon.DynamoDBv2.DataModel;
using ADT.Flareon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Domain.Tables
{
    [DynamoDBTable("Flareon_Product")]
    public class ProductTable: AuditableTable
    {
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
