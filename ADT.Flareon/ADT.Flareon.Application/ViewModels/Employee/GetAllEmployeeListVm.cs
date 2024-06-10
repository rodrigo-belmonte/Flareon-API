using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.ViewModels.Employee
{
    public class GetAllEmployeeListVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string HiringType { get; set; }
        public string Occupation { get; set; }
        public DateTime DtAdmission { get; set; }

        public DateTime DtCreation { get; set; }
        public DateTime DtLastUpdate { get; set; }
    }
}
