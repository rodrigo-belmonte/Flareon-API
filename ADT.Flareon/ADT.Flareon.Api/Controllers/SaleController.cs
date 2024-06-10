using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ADT.Flareon.Application.Responses;
using ADT.Flareon.Application.Services.Sale.Commands.Create;
using ADT.Flareon.Application.Services.Sale.Commands.Delete;
using ADT.Flareon.Application.Services.Sale.Commands.Update;
using ADT.Flareon.Application.Services.Sale.Queries.GetAll;
using ADT.Flareon.Application.Services.Sale.Queries.GetById;
using ADT.Flareon.Application.Services.Sale.Queries.GetFiltered;

namespace ADT.Flareon.Api.Controllers
{
    [Route("api/[controller]")]
    public class SaleController : Controller
    {
        private readonly IMediator _mediator;

        public SaleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllSales")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetAllSaleResponse>> GetAllSales()
        {
            var response = await _mediator.Send(new GetAllSaleQuery());
            return Ok(response);
        }


        [HttpGet("{id}", Name = "GetSaleById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetByIdSaleResponse>> GetSaleById(Guid Id)
        {
            var getSaleByIdQuery = new GetByIdSaleQuery() { Id = Id };
            var response = await _mediator.Send(getSaleByIdQuery);

            return Ok(response);
        }

        [HttpPost(Name = "NewSale")]
        public async Task<ActionResult<BaseResponse>> NewSale([FromBody] CreateSaleCommand createSaleCommand)
        {
            var response = await _mediator.Send(createSaleCommand);

            return Ok(response);
        }

        [HttpPut(Name = "UpdateSale")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateSale([FromBody] UpdateSaleCommand updateSaleCommand)
        {
            var response = await _mediator.Send(updateSaleCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteSale")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteSale(Guid Id)
        {
            var deleteProducCommand = new DeleteSaleCommand() { Id = Id };
            var response = await _mediator.Send(deleteProducCommand);
            return Ok(response);
        }

        [HttpGet("GetSales", Name = "GetSales")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetSales( GetFilteredQuery getFilteredQuery) 
        {
            var response = await _mediator.Send(getFilteredQuery);   
            return Ok(response);
        }
    }
}
