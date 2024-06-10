using MediatR;
using ADT.Flareon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Product.Commands.Delete
{
    public class DeleteProductCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
    }
}
