using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ADT.Flareon.Application.Responses;
using ADT.Flareon.Application.Services.Product.Commands.Create;
using ADT.Flareon.Application.Services.Product.Commands.Delete;
using ADT.Flareon.Application.Services.Product.Commands.Update;
using ADT.Flareon.Application.Services.Product.Queries.GetAll;
using ADT.Flareon.Application.Services.Product.Queries.GetById;

namespace ADT.Flareon.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetAllProductResponse>> GetProducts()
        {
            var response = await _mediator.Send(new GetAllProductQuery());
            return Ok(response);
        }


        [HttpGet("{id}", Name = "GetProductById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetByIdProductResponse>> GetProductById(Guid Id)
        {
            var getProductByIdQuery = new GetByIdProductQuery() { Id = Id };
            var response = await _mediator.Send(getProductByIdQuery);

            return Ok(response);
        }

        [HttpPost( Name = "NewProduct")]
        public async Task<ActionResult<BaseResponse>> NewProduct([FromBody] CreateProductCommand createProductCommand)
        {
            var response = await _mediator.Send(createProductCommand);

            return Ok(response);
        }

        [HttpPut(Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateProduct([FromBody] UpdateProductCommand updateProductCommand)
        {
            var response = await _mediator.Send(updateProductCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteProduct(Guid Id)
        {
            var deleteProducCommand = new DeleteProductCommand(){ Id = Id};
            var response = await _mediator.Send(deleteProducCommand);
            return Ok(response);
        }
    }
}
