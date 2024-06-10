using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ADT.Flareon.Application.Intefaces.Persistence;
using ADT.Flareon.Domain.Tables;
using AutoMapper;
using ADT.Flareon.Application.Responses;

namespace ADT.Flareon.Application.Services.Product.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<ProductTable> _productRepository;

        public CreateProductCommandHandler(IMapper mapper, IAsyncRepository<ProductTable> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<BaseResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            try
            {
                var product = _mapper.Map<ProductTable>(request);
                product.Id = Guid.NewGuid();
                product.DtCreation = DateTime.Now;
                product.DtLastUpdate = DateTime.Now;
                await _productRepository.AddAsync(product);
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
