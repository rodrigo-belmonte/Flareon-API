using Amazon.DynamoDBv2.DataModel;
using ADT.Flareon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Domain.Tables
{
    [DynamoDBTable("Flareon_Sale")]
    public class SaleTable: AuditableTable
    {
        public string OrderId { get; set; }
        public int OrderNumber { get; set; }
        public string PaymentType { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DtSale { get; set; }
        public int Installments { get; set; }
        public float TotalValue { get; set; }
    }
}
