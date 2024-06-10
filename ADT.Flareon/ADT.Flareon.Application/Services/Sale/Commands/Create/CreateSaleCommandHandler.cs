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

namespace ADT.Flareon.Application.Services.Sale.Commands.Create
{
    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, BaseResponse>
    {
        private readonly IAsyncRepository<SaleTable> _saleRepository;
        private readonly IAsyncRepository<OrderTable> _orderRepository;
        private readonly IMapper _mapper;

        public CreateSaleCommandHandler(IMapper mapper, IAsyncRepository<SaleTable> saleRepository, IAsyncRepository<OrderTable> orderRepository)
        {
            _mapper = mapper;
            _saleRepository = saleRepository;
            _orderRepository = orderRepository;
        }

        public async Task<BaseResponse> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            try
            {
                var sale = _mapper.Map<SaleTable>(request);
                var order = await _orderRepository.GetByIdAsync(Guid.Parse(sale.OrderId));

                sale.Id = Guid.NewGuid();
                sale.DtSale = DateTime.Now;
                sale.EmployeeId = order.EmployeeId;
                sale.EmployeeName = order.EmployeeName;
                sale.CustomerId = order.CustomerId;
                sale.CustomerName = order.CustomerName;
                sale.OrderNumber = order.OrderNumber;
                order.Open = false;

                await _saleRepository.AddAsync(sale);
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
