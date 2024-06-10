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
using ADT.Flareon.Application.ViewModels.Order;

namespace ADT.Flareon.Application.Services.Order.Queries.GetAll
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, GetAllOrderResponse>
    {
        private readonly IAsyncRepository<OrderTable> _orderRepository;
        private readonly IAsyncRepository<EmployeeTable> _employeeRepository;
        private readonly IAsyncRepository<CustomerTable> _customerRepository;
        private readonly IMapper _mapper;

        public GetAllOrderQueryHandler(IMapper mapper, IAsyncRepository<OrderTable> orderRepository, 
            IAsyncRepository<EmployeeTable> employeeRepository, IAsyncRepository<CustomerTable> customerRepository)
        {
			_mapper = mapper;
			_orderRepository = orderRepository;
            _employeeRepository = employeeRepository;
            _customerRepository = customerRepository;
        }

        public async Task<GetAllOrderResponse> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {   
            var response = new GetAllOrderResponse();

            try
            {
                var orderList = await _orderRepository.ListAllAsync();
                response.OrderList = _mapper.Map<List<GetAllOrderListVm>>(orderList.OrderByDescending(o => o.OrderNumber));

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
