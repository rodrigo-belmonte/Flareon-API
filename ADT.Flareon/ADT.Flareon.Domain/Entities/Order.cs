using ADT.Flareon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Domain.Entities
{
    public class Order: AuditableEntity
    {
        public DateTime OrderDate { get; set; }
        public double TotalValue { get; set; }
        public bool Production { get; set; }
        public int IdCustomer { get; set; }
        public Customer Customer { get; set; } = new Customer();
        public int IdEmployee { get; set; }
        public Employee Employee { get; set; } = new Employee();
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
    }
}
