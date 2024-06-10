using ADT.Flareon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Domain.Entities
{
    public class Product: AuditableEntity
    {
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
