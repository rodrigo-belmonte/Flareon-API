using ADT.Flareon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Domain.Entities
{
    public class Employee: AuditableEntity
    {
        public string Name { get; set; } = string.Empty; 
        public string LastName { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
        public DateTime DtAdmission { get; set; }
    }
}
