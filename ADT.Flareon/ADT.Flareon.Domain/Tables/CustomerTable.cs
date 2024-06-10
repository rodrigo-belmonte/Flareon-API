using Amazon.DynamoDBv2.DataModel;
using ADT.Flareon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Domain.Tables
{
    [DynamoDBTable("Flareon_Customer")]
    public class CustomerTable : AuditableTable
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }

        //Address
        public string CEP { get; set; }
        public string StreetAddress { get; set; } 
        public string AddressNumber { get; set; }
        public string Neighborhood { get; set; } 
        public string AddressComplement { get; set; }
        public string City { get; set; }
        public string State { get; set; } 

        //Measures
        public float MeasureShoulder { get ; set; } 
        public float MeasureLeftArm { get; set; } 
        public float MeasureRightArm { get; set; } 
        public float MeasureChest { get; set; }
        public float MeasureWaist { get; set; }
        public float MeasureNavelHeight { get; set; } 
        public float MeasureHip { get; set; } 
        public float MeasureLeftLeg { get; set; }
        public float MeasureRightLeg { get; set; }
        public float MeasureLeftCalf { get; set; } 
        public float MeasureRightCalf { get; set; } 

    }
}
