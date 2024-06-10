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

namespace ADT.Flareon.Application.Services.Customer.Queries.GetAll
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, GetAllCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<CustomerTable> _customerRepository;

        public GetAllCustomerQueryHandler(IMapper mapper, IAsyncRepository<CustomerTable> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<GetAllCustomerResponse> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var response = new GetAllCustomerResponse();

            try
            {
                var customerList = await _customerRepository.ListAllAsync();
                response.CustomerList = _mapper.Map<List<GetAllCustomerListVm>>(customerList.OrderByDescending(c => c.DtCreation));
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
