using ADT.Flareon.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Sale.Commands.Create
{
    public class CreateSaleCommand : IRequest<BaseResponse>
    {
        public string OrderId { get; set; }
        public string PaymentType { get; set; }
        public DateTime DtSale { get; set; }
        public string Installments { get; set; }
        public float TotalValue { get; set; }
    }
}
