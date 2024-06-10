using MediatR;
using ADT.Flareon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Customer.Commands.Update
{
    public class UpdateCustomerCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
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
        public string MeasureShoulder { get; set; }
        public string MeasureLeftArm { get; set; }
        public string MeasureRightArm { get; set; }
        public string MeasureChest { get; set; }
        public string MeasureWaist { get; set; }
        public string MeasureNavelHeight { get; set; }
        public string MeasureHip { get; set; }
        public string MeasureLeftLeg { get; set; }
        public string MeasureRightLeg { get; set; }
        public string MeasureLeftCalf { get; set; }
        public string MeasureRightCalf { get; set; }

    }
}
