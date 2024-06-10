using ADT.Flareon.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Sale.Commands.Update
{
    public class UpdateSaleCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
        public string PaymentType { get; set; }
        public int Installments { get; set; }
        public DateTime DtSale { get; set; }
    }
}
