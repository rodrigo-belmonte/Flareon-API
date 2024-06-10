using ADT.Flareon.Application.ViewModels.Customer;
using ADT.Flareon.Application.ViewModels.Employee;
using ADT.Flareon.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.ViewModels.Order
{
    public class OrderVm
    {
        public Guid Id { get; set; }
        public int OrderNumber { get; set; }
        public IEnumerable<PieceClothingVm> Pieces { get; set; }
        public CustomerSelectVm Customer { get; set; }
        public EmployeeSelectVm Employee { get; set; }
        public DateTime DtOrder { get; set; }
        public DateTime DtWithdrawal { get; set; }
        public DateTime DtCompletion { get; set; }
        public bool Production { get; set; }
        public float TotalValue { get; set; }

    }
}
