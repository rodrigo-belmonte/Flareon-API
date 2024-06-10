using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ADT.Flareon.Application.Services.Order.Commands.Create;
using ADT.Flareon.Application.Services.Order.Commands.Delete;
using ADT.Flareon.Application.Services.Order.Commands.Update;
using ADT.Flareon.Application.Services.Order.Queries.GetAll;
using ADT.Flareon.Application.Services.Order.Queries.GetById;
using ADT.Flareon.Application.Responses;
using ADT.Flareon.Application.Services.Order.Queries.GetPiecesByOrderId;

namespace ADT.Flareon.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetAllOrderResponse>> GetOrders()
        {
            var response = await _mediator.Send(new GetAllOrderQuery());
            return Ok(response);
        }
        [HttpGet("{id}", Name = "GetOrderById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetByIdOrderResponse>> GetOrderById(Guid Id)
        {
            var getOrderByIdQuery = new GetByIdOrderQuery() { Id = Id };
            var response = await _mediator.Send(getOrderByIdQuery);

            return Ok(response);
        }

        [HttpGet("GetPieces/{id}", Name = "GetPiecesByOrderId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetPiecesByOrderIdResponse>> GetPiecesByOrderId(string Id)
        {
            var getPiecesByOrderIdQuery = new GetPiecesByOrderIdQuery() { Id = Id };
            var response = await _mediator.Send(getPiecesByOrderIdQuery);

            return Ok(response);
        }

        [HttpPost(Name = "NewOrder")]
        public async Task<ActionResult<BaseResponse>> NewOrder([FromBody] CreateOrderCommand createOrderCommand)
        {
            var response = await _mediator.Send(createOrderCommand);

            return Ok(response);
        }

        [HttpPut(Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderCommand updateOrderCommand)
        {
            var response = await _mediator.Send(updateOrderCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrder(Guid Id)
        {
            var deleteProducCommand = new DeleteOrderCommand() { Id = Id };
            var response = await _mediator.Send(deleteProducCommand);
            return Ok(response);
        }

        

        //[HttpPut(Name = "CloseOrder")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesDefaultResponseType]
        //public async Task<ActionResult> CloseOrder([FromBody] UpdateOrderCommand updateOrderCommand)
        //{
        //    var response = await _mediator.Send(updateOrderCommand);
        //    return Ok(response);
        //}

    }
}
