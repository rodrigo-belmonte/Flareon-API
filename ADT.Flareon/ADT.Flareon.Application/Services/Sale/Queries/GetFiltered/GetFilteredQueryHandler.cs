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
using System.Globalization;

namespace ADT.Flareon.Application.Services.Sale.Queries.GetFiltered
{
    public class GetFilteredQueryHandler : IRequestHandler<GetFilteredQuery, GetFilteredResponse>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public GetFilteredQueryHandler(IMapper mapper, ISaleRepository saleRepository)
        {
            _mapper = mapper;
            _saleRepository = saleRepository;
        }

        public async Task<GetFilteredResponse> Handle(GetFilteredQuery request, CancellationToken cancellationToken)
        {
            var response = new GetFilteredResponse();
            try
            {

                var startDate = DateTime.ParseExact(request.StartDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-br"));
                var endDate = DateTime.ParseExact(request.EndDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-br"));
                var sales = await _saleRepository
                                    .GetFiteredAsync(
                                    new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0), 
                                    new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59), 
                                    request.EmployeeId == null ? "" : request.EmployeeId
                                    );

                response.SaleList = _mapper.Map<List<GetAllSaleListVm>>(sales);
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
