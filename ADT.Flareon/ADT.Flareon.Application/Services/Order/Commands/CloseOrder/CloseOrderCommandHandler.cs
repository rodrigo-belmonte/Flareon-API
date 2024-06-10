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

namespace ADT.Flareon.Application.Services.Order.Commands.CloseOrder
{
    public class CloseOrderCommandHandler : IRequestHandler<CloseOrderCommand, BaseResponse>
    {
        private readonly IAsyncRepository<OrderTable> _orderRepository;
        private readonly IMapper _mapper;

        public CloseOrderCommandHandler(IMapper mapper, IAsyncRepository<OrderTable> orderRepository)
        {
			_mapper = mapper;
			_orderRepository = orderRepository;
        }

        public async Task<BaseResponse> Handle(CloseOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            try
            {
                var order = await _orderRepository.GetByIdAsync(request.Id);
                order.Open = false;

                await _orderRepository.UpdateAsync(order);

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
