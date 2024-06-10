using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.ViewModels.Customer
{
    public class GetAllCustomerListVm
    {
        

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        //Address
        public string Neighborhood { get; set; }
        public string City { get; set; }

        public DateTime DtCreation { get; set; }
        public DateTime DtLastUpdate { get; set; }
    }
}
