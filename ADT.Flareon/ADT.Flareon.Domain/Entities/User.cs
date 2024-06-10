using ADT.Flareon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Domain.Entities
{
    public class User: AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Telephone { get; set; } = 0;
        public string Password { get; set; } = string.Empty;
        public int ProfileId { get; set; } = 0;
        public Profile Profile { get; set; } = new Profile();
    }
  
}
