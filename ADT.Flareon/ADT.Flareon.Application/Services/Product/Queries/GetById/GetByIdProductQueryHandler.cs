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
using ADT.Flareon.Application.ViewModels.Product;

namespace ADT.Flareon.Application.Services.Product.Queries.GetById
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, GetByIdProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<ProductTable> _productRepository;

        public GetByIdProductQueryHandler(IMapper mapper, IAsyncRepository<ProductTable> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<GetByIdProductResponse> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var response = new GetByIdProductResponse();

            try
            {
                var product = await _productRepository.GetByIdAsync(request.Id);
                response.Product = _mapper.Map<ProductVm>(product);
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
