using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Employee.Queries.GetById
{
    public class GetEmployeeByIdQuery : IRequest<GetEmployeeByIdResponse>
    {
        public Guid Id { get; set; }
    }
}
