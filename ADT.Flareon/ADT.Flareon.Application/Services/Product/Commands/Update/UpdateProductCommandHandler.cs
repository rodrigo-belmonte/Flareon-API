using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADT.Flareon.Application.Intefaces.Persistence;
using ADT.Flareon.Domain.Tables;
using AutoMapper;
using ADT.Flareon.Application.Responses;

namespace ADT.Flareon.Application.Services.Product.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<ProductTable> _productRepository;

        public UpdateProductCommandHandler(IMapper mapper, IAsyncRepository<ProductTable> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<BaseResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            try
            {
                var product = _mapper.Map<ProductTable>(request);
                product.DtLastUpdate = DateTime.Now;
                await _productRepository.UpdateAsync(product);
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
