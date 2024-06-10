using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Order.Queries.GetById
{
    public class GetByIdOrderQuery : IRequest<GetByIdOrderResponse>
    {
        public Guid Id { get; set; }        
    }
}
