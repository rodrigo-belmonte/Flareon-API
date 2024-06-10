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

namespace ADT.Flareon.Application.Services.Sale.Commands.Update
{
    public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleCommand, BaseResponse>
    {
        private readonly IAsyncRepository<SaleTable> _saleRepository;
        private readonly IMapper _mapper;

        public UpdateSaleCommandHandler(IMapper mapper, IAsyncRepository<SaleTable> saleRepository)
        {
			_mapper = mapper;
			_saleRepository = saleRepository;
        }

        public async Task<BaseResponse> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            var sale = await _saleRepository.GetByIdAsync(request.Id);

            try
            {
                sale.Installments = request.Installments;
                sale.PaymentType = request.PaymentType;
                sale.DtSale = DateTime.Now;
                await _saleRepository.UpdateAsync(sale);
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
