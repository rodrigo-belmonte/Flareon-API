using MediatR;
using ADT.Flareon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADT.Flareon.Application.ViewModels.Product;

namespace ADT.Flareon.Application.Services.Order.Commands.Create
{
    public class CreateOrderCommand : IRequest<CreateOrderResponse>
    {
        public IEnumerable<PieceClothingVm> Pieces { get; set; }
        public string CustomerId { get; set; }
        public string EmployeeId { get; set; }
        public bool Production { get; set; }
        public float TotalValue { get; set; }
        public string DtWithdrawal { get; set; }

    }
}
