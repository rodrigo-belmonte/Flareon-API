using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.ViewModels.Product
{
    public class ProductVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtLastUpdate { get; set; }
    }
}
