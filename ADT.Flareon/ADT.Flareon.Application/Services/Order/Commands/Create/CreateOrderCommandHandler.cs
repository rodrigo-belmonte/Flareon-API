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

namespace ADT.Flareon.Application.Services.Order.Commands.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
    {
        private readonly IAsyncRepository<OrderTable> _orderRepository;
        private readonly IAsyncRepository<CustomerTable> _customerRepository;
        private readonly IAsyncRepository<EmployeeTable> _employeeRepository;
        private readonly IAsyncRepository<OrderLastInsertedIdTable> _orderLastInsertedIdRepositry;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IMapper mapper, IAsyncRepository<OrderTable> orderRepository,
            IAsyncRepository<CustomerTable> customerRepository,
            IAsyncRepository<EmployeeTable> employeeRepository,
            IAsyncRepository<OrderLastInsertedIdTable> orderLastInsertedIdRepositry
            )
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _employeeRepository = employeeRepository;
            _orderLastInsertedIdRepositry = orderLastInsertedIdRepositry;
        }

        public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            var response = new CreateOrderResponse();
            
            try
            {
                var order = _mapper.Map<OrderTable>(request);
                var lastInsertedId = await _orderLastInsertedIdRepositry.GetByIdAsync(1);
                int orderNumber = lastInsertedId.LastSequencialId + 1;
                lastInsertedId.LastSequencialId = orderNumber;


                var customer = await _customerRepository.GetByIdAsync(Guid.Parse(order.CustomerId));
                var employee = await _employeeRepository.GetByIdAsync(Guid.Parse(order.EmployeeId));
                order.CustomerName = customer.Name;
                order.EmployeeName = employee.Name;
                order.Id = Guid.NewGuid();
                order.DtOrder = DateTime.Now;
                order.DtWithdrawal = DateTime.Parse(request.DtWithdrawal);
                order.DtCompletion = order.DtWithdrawal.AddDays(-2);
                order.Open = true;
                order.OrderNumber = orderNumber;
                order.DtCreation = DateTime.Now;
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
                    orderTotal += pieceTotal;
                }

                order.TotalValue = orderTotal;

                await _orderRepository.AddAsync(order);

                await _orderLastInsertedIdRepositry.UpdateAsync(lastInsertedId);
                response.OrderId = order.Id;
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
