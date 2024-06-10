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
using System.Globalization;

namespace ADT.Flareon.Application.Services.Order.Commands.Update
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, BaseResponse>
    {
        private readonly IAsyncRepository<OrderTable> _orderRepository;
        private readonly IAsyncRepository<CustomerTable> _customerRepository;
        private readonly IAsyncRepository<EmployeeTable> _employeeRepository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IMapper mapper, IAsyncRepository<OrderTable> orderRepository,
             IAsyncRepository<CustomerTable> customerRepository,
            IAsyncRepository<EmployeeTable> employeeRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<BaseResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            var response = new BaseResponse();

            try
            {

                var order = _mapper.Map<OrderTable>(request);
                var customer = await _customerRepository.GetByIdAsync(Guid.Parse(order.CustomerId));
                var employee = await _employeeRepository.GetByIdAsync(Guid.Parse(order.EmployeeId));
                order.CustomerName = customer.Name;
                order.EmployeeName = employee.Name;
                order.DtWithdrawal = DateTime.Parse(request.DtWithdrawal);
                order.DtCompletion = order.DtWithdrawal.AddDays(-2);
                order.DtLastUpdate = DateTime.Now;
                float orderTotal = 0;
                foreach (var piece in order.Pieces)
                {
                    float pieceTotal = 0;

                    foreach (var prod in piece.Products)
                    {
                        var totalProd = prod.Price * prod.Quantity;
                        pieceTotal += totalProd;
                    }

                    piece.Total = pieceTotal;
                    orderTotal+= pieceTotal;
                }

                order.TotalValue = orderTotal;
                order.Open = true;
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
