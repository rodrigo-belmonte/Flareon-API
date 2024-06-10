using Amazon.DynamoDBv2.DataModel;
using ADT.Flareon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Domain.Tables
{
    [DynamoDBTable("Flareon_User")]
    public class UserTable : AuditableTable
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
    }

}
