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

namespace ADT.Flareon.Application.Services.Sale.Commands.Delete
{
    public class DeleteSaleCommandHandler : IRequestHandler<DeleteSaleCommand, BaseResponse>
    {
        private readonly IAsyncRepository<SaleTable> _saleRepository;
        private readonly IMapper _mapper;

        public DeleteSaleCommandHandler(IMapper mapper, IAsyncRepository<SaleTable> saleRepository)
        {
            _mapper = mapper;
            _saleRepository = saleRepository;
        }

        public async Task<BaseResponse> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            try
            {
                await _saleRepository.DeleteAsync(request.Id);
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
