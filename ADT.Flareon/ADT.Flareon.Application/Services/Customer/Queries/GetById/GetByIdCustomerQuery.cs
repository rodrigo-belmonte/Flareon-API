using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Customer.Queries.GetById
{
    public class GetByIdCustomerQuery : IRequest<GetByIdCustomerResponse>
    {
        public Guid Id { get; set; }
    }
}
