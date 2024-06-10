using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.ViewModels.Sale
{
    public class GetAllSaleListVm
    {
        public Guid Id { get; set; }
        public string OrderId { get; set; }
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public string PaymentType { get; set; }
        public DateTime DtSale { get; set; }
        public float TotalValue { get; set; }

        public DateTime DtCreation { get; set; }
        public DateTime DtLastUpdate { get; set; }



    }
}
