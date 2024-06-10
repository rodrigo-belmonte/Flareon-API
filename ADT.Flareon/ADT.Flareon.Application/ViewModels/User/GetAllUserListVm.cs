using ADT.Flareon.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.ViewModels.User
{
    public class GetAllUserListVm
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }

        public DateTime DtCreation { get; set; }
        public DateTime DtLastUpdate { get; set; }

    }
}
