﻿using Amazon.DynamoDBv2.DataModel;
using ADT.Flareon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Domain.Tables
{
    [DynamoDBTable("Flareon_Employee")]
    public class EmployeeTable : AuditableTable
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public DateTime DtBirth { get; set; }


        //Address
        public string CEP { get; set; }
        public string StreetAddress { get; set; }
        public string AddressNumber { get; set; }
        public string Neighborhood { get; set; }
        public string AddressComplement { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public string HiringType { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string Occupation { get; set; }
        public DateTime DtAdmission { get; set; }
        public int PaymentDay { get; set; }
        public float Wage { get; set; }
    }
}
