using ADT.Flareon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Domain.Entities
{
    public class Profile: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
