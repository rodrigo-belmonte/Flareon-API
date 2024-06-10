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
using ADT.Flareon.Application.ViewModels.Sale;

namespace ADT.Flareon.Application.Services.Sale.Queries.GetAll
{
    public class GetAllSaleQueryHandler : IRequestHandler<GetAllSaleQuery, GetAllSaleResponse>
    {
        private readonly IAsyncRepository<SaleTable> _saleRepository;
        private readonly IMapper _mapper;

        public GetAllSaleQueryHandler(IMapper mapper, IAsyncRepository<SaleTable> saleRepository)
        {
			_mapper = mapper;
			_saleRepository = saleRepository;
        }

        public async Task<GetAllSaleResponse> Handle(GetAllSaleQuery request, CancellationToken cancellationToken)
        {
            var response = new GetAllSaleResponse();

            try
            {
                var saleList = await _saleRepository.ListAllAsync();
                response.SaleList = _mapper.Map<List<GetAllSaleListVm>>(saleList);

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
