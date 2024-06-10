using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Sale.Queries.GetById
{
    public class GetByIdSaleQuery : IRequest<GetByIdSaleResponse>
    {
        public Guid Id { get; set; }

    }
}
