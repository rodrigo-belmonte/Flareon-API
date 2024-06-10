using ADT.Flareon.Domain.Common;
using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Domain.Tables
{
    [DynamoDBTable("Flareon_Order_LastInsertedId")]

    public class OrderLastInsertedIdTable 
    {
        public int Id { get; set; }
        public int LastSequencialId { get; set; }
    }
}
