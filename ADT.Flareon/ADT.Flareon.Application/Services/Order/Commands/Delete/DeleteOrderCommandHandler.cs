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

namespace ADT.Flareon.Application.Services.Order.Commands.Delete
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, BaseResponse>
    {
        private readonly IAsyncRepository<OrderTable> _orderRepository;
        private readonly IMapper _mapper;

        public DeleteOrderCommandHandler(IMapper mapper, IAsyncRepository<OrderTable> orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<BaseResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            try
            {
                await _orderRepository.DeleteAsync(request.Id);
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
