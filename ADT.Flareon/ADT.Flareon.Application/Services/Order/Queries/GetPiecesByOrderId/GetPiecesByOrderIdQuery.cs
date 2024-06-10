using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Order.Queries.GetPiecesByOrderId
{
    public class GetPiecesByOrderIdQuery : IRequest<GetPiecesByOrderIdResponse>
    {
        public string Id { get; set; }

    }
}
