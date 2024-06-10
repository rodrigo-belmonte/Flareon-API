using MediatR;
using ADT.Flareon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Product.Commands.Create
{
    public class CreateProductCommand : IRequest<BaseResponse>
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
