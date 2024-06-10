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
using ADT.Flareon.Application.ViewModels.Product;
using ADT.Flareon.Application.ViewModels.Order;
using ADT.Flareon.Application.ViewModels.Employee;
using ADT.Flareon.Application.ViewModels.Customer;

namespace ADT.Flareon.Application.Services.Order.Queries.GetById
{
    public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQuery, GetByIdOrderResponse>
    {
        private readonly IAsyncRepository<OrderTable> _orderRepository;
        private readonly IAsyncRepository<EmployeeTable> _employeeRepository;
        private readonly IAsyncRepository<CustomerTable> _customerRepository;
        private readonly IMapper _mapper;

        public GetByIdOrderQueryHandler(IMapper mapper, IAsyncRepository<OrderTable> orderRepository, 
            IAsyncRepository<EmployeeTable> employeeRepository, IAsyncRepository<CustomerTable> customerRepository)
        {
			_mapper = mapper;
			_orderRepository = orderRepository;
            _employeeRepository = employeeRepository;
            _customerRepository = customerRepository;
        }

        public async Task<GetByIdOrderResponse> Handle(GetByIdOrderQuery request, CancellationToken cancellationToken)
        {
            var response = new GetByIdOrderResponse();

            try
            {
                var order = await _orderRepository.GetByIdAsync(request.Id);

                var employee = await _employeeRepository.GetByIdAsync(Guid.Parse(order.EmployeeId));
                var customer = await _customerRepository.GetByIdAsync(Guid.Parse(order.CustomerId));

                response.Order = _mapper.Map<GetByIdOrderVm>(order);
                response.Order.Employee = _mapper.Map<EmployeeSelectVm>(employee);
                response.Order.Customer = _mapper.Map<CustomerSelectVm>(customer);
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
