using Amazon.DynamoDBv2.DataModel;
using ADT.Flareon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Domain.Tables
{
    [DynamoDBTable("Flareon_Order")]
    public class OrderTable : AuditableTable
    {
        public int OrderNumber { get; set; }
        public List<PieceClothing> Pieces { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DtOrder { get; set; }
        public DateTime DtWithdrawal { get; set; }
        public DateTime DtCompletion { get; set; }
        public bool Production { get; set; }
        public bool Open { get; set; }
        public float TotalValue { get; set; }
    }

    public class PieceClothing
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SelectedProducts> Products { get; set; }
        public float Total { get; set; }
    }
    public class SelectedProducts
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Obs { get; set; }
        public float Total { get; set; }
    }
}
