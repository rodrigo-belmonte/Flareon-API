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
using ADT.Flareon.Application.ViewModels.Product;

namespace ADT.Flareon.Application.Services.Product.Queries.GetAll
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, GetAllProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<ProductTable> _productRepository;

        public GetAllProductQueryHandler(IMapper mapper, IAsyncRepository<ProductTable> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<GetAllProductResponse> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var response = new GetAllProductResponse();

            try
            {
                var productList = await _productRepository.ListAllAsync();
                response.ProductList = _mapper.Map<List<ProductVm>>(productList);
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
