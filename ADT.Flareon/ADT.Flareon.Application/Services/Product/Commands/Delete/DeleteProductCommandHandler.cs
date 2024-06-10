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

namespace ADT.Flareon.Application.Services.Product.Commands.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<ProductTable> _productRepository;

        public DeleteProductCommandHandler(IMapper mapper, IAsyncRepository<ProductTable> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<BaseResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            try
            {
                await _productRepository.DeleteAsync(request.Id);
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
