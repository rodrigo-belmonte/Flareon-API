using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ADT.Flareon.Application.Intefaces.Persistence;
using ADT.Flareon.Domain.Tables;
using ADT.Flareon.Application.ViewModels.Customer;

namespace ADT.Flareon.Application.Services.Customer.Queries.GetById
{
    public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQuery, GetByIdCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<CustomerTable> _customerRepository;

        public GetByIdCustomerQueryHandler(IMapper mapper, IAsyncRepository<CustomerTable> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<GetByIdCustomerResponse> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerResponse();

            try
            {
                var customer = await _customerRepository.GetByIdAsync(request.Id);
                response.Customer = _mapper.Map<GetByIdCustomerVm>(customer);
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
