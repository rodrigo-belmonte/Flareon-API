using ADT.Flareon.Application.Responses;
using AutoMapper;
using ADT.Flareon.Domain.Tables;
using ADT.Flareon.Application.Intefaces.Persistence;
using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADT.Flareon.Application.Services.Order.Queries.GetById;
using ADT.Flareon.Application.ViewModels.Customer;
using ADT.Flareon.Application.ViewModels.Employee;
using ADT.Flareon.Application.ViewModels.Order;
using ADT.Flareon.Application.ViewModels.Product;

namespace ADT.Flareon.Application.Services.Order.Queries.GetPiecesByOrderId
{
    public class GetPiecesByOrderIdQueryHandler : IRequestHandler<GetPiecesByOrderIdQuery, GetPiecesByOrderIdResponse>
    {
        private readonly IAsyncRepository<OrderTable> _orderRepository;
        private readonly IMapper _mapper;

        public GetPiecesByOrderIdQueryHandler(IMapper mapper, IAsyncRepository<OrderTable> orderRepository)
        {
			_mapper = mapper;
			_orderRepository = orderRepository;
        }

        public async Task<GetPiecesByOrderIdResponse> Handle(GetPiecesByOrderIdQuery request, CancellationToken cancellationToken)
        {
            var response = new GetPiecesByOrderIdResponse();

            try
            {
                var order = await _orderRepository.GetByIdAsync(Guid.Parse(request.Id));

                response.OrderNumber = order.OrderNumber;
                response.Pieces = _mapper.Map<IEnumerable<PieceClothingVm>>(order.Pieces);
               
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ValidationErrors = new List<string> { ex.Message };
            }

            return response;
        }
    }
}
