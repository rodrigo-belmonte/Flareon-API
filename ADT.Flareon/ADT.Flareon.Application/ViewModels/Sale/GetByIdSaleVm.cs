using ADT.Flareon.Application.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.ViewModels.Sale
{
    public class GetByIdSaleVm
    {
        public Guid Id { get; set; }
        public OrderVm Order { get; set; }
        public string PaymentType { get; set; }
        public DateTime DtSale { get; set; }
        public int Installments { get; set; }
        public float TotalValue { get; set; }
    }
}