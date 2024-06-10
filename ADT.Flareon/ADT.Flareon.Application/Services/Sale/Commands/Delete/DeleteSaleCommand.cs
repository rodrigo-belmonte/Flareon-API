using ADT.Flareon.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Sale.Commands.Delete
{
    public class DeleteSaleCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }

    }
}
