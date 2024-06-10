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
using ADT.Flareon.Application.ViewModels.Sale;
using ADT.Flareon.Application.ViewModels.Product;
using ADT.Flareon.Application.ViewModels.Employee;
using ADT.Flareon.Application.ViewModels.Customer;

namespace ADT.Flareon.Application.Services.Sale.Queries.GetById
{
    public class GetByIdSaleQueryHandler : IRequestHandler<GetByIdSaleQuery, GetByIdSaleResponse>
    {
        private readonly IAsyncRepository<SaleTable> _saleRepository;
        private readonly IAsyncRepository<OrderTable> _orderRepository;
        private readonly IAsyncRepository<ProductTable> _productRepository;
        private readonly IAsyncRepository<EmployeeTable> _employeeRepository;
        private readonly IAsyncRepository<CustomerTable> _customerRepository;
        private readonly IMapper _mapper;

        public GetByIdSaleQueryHandler(IMapper mapper, IAsyncRepository<SaleTable> saleRepository, IAsyncRepository<OrderTable> orderRepository,
             IAsyncRepository<ProductTable> productRepository,
            IAsyncRepository<EmployeeTable> employeeRepository, IAsyncRepository<CustomerTable> customerRepository)
        {
			_mapper = mapper;
			_saleRepository = saleRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _employeeRepository = employeeRepository;
            _customerRepository = customerRepository;
        }

        public async Task<GetByIdSaleResponse> Handle(GetByIdSaleQuery request, CancellationToken cancellationToken)
        {
            var response = new GetByIdSaleResponse();

            try
            {
                var sale = await _saleRepository.GetByIdAsync(request.Id);
                var order = await _orderRepository.GetByIdAsync(Guid.Parse(sale.OrderId));
                //var products = new List<ProductVm>();

                //foreach (var productId in order.ProductIds)
                //{
                //    var product = await _productRepository.GetByIdAsync(productId);
                //    products.Add(_mapper.Map<ProductVm>(product));
                //}
                var employee = await _employeeRepository.GetByIdAsync(Guid.Parse(order.EmployeeId));
                var customer = await _customerRepository.GetByIdAsync(Guid.Parse(order.CustomerId));

                var orderVm = _mapper.Map<OrderVm>(order);
                //orderVm.Products = products;
                orderVm.Employee = _mapper.Map<EmployeeSelectVm>(employee);
                orderVm.Customer = _mapper.Map<CustomerSelectVm>(customer);

                response.Sale = _mapper.Map<GetByIdSaleVm>(sale);
                response.Sale.Order = orderVm;
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
