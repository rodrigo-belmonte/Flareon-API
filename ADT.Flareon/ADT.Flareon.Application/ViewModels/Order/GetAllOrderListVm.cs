using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.ViewModels.Order
{
    public class GetAllOrderListVm
    {
        public Guid Id { get; set; }
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DtOrder { get; set; }
        public DateTime DtWithdrawal { get; set; }
        public DateTime DtCompletion { get; set; }
        public bool Production { get; set; }
        public float TotalValue { get; set; }
        public float Open { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtLastUpdate { get; set; }
    }
}
