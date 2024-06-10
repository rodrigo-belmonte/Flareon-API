using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADT.Flareon.Application.Responses;
using AutoMapper;
using ADT.Flareon.Application.Intefaces.Persistence;
using ADT.Flareon.Domain.Tables;

namespace ADT.Flareon.Application.Services.Customer.Commands.Delete
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<CustomerTable> _customerRepository;
        public DeleteCustomerCommandHandler(IMapper mapper, IAsyncRepository<CustomerTable> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<BaseResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            try
            {
                await _customerRepository.DeleteAsync(request.Id);
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
