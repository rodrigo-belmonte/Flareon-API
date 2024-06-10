using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADT.Flareon.Domain.Tables;
using ADT.Flareon.Application.Intefaces.Persistence;
using AutoMapper;
using ADT.Flareon.Application.Responses;

namespace ADT.Flareon.Application.Services.Customer.Commands.Create
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<CustomerTable> _customerRepository;
        public CreateCustomerCommandHandler(IMapper mapper, IAsyncRepository<CustomerTable> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<BaseResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            try
            {
                var customer = _mapper.Map<CustomerTable>(request);
                customer.Id = Guid.NewGuid();
                customer.DtCreation = DateTime.Now;
                customer.DtLastUpdate = DateTime.Now;
                await _customerRepository.AddAsync(customer);
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
