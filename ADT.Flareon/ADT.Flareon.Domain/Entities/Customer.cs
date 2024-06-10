using ADT.Flareon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Domain.Entities
{
    public class Customer: AuditableEntity
    {
        public string Name { get; set; }= string.Empty;
        public string Sex { get; set; } = string.Empty;
        public int Telephone { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public int CPF { get; set; } = 0;

        //Address
        public int CEP { get; set; }
        public string StreetAddress { get; set; } = string.Empty;
        public int AddressNumber { get; set; } = 0;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        
        //Measures
        public float Shoulder { get; set; } = float.MinValue;
        public float LeftArm { get; set; } = float.MinValue;
        public float RightArm { get; set; } = float.MinValue;
        public float Chest { get; set; } = float.MinValue;
        public float Waist { get; set; } = float.MinValue;
        public float NavelHeight { get; set; } = float.MinValue;
        public float Hip { get; set; } = float.MinValue;
        public float LeftLeg { get; set; } = float.MinValue;
        public float RightLeg { get; set; } = float.MinValue;
        public float LeftCalf { get; set; } = float.MinValue;
        public float RightCalf { get; set; } = float.MinValue;
    }
}
