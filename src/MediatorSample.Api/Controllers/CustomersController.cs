using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using MediatorSample.Domain.Commands;
using MediatorSample.Domain.Commands.Responses;
using MediatorSample.Domain.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorSample.Api.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create a Customer.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST ...
        ///     {}
        ///
        /// </remarks>
        /// <param name="command"></param>
        /// <param name="handler"></param>
        /// <returns>Customer created.</returns>
        /// <response code="201">Customer created.</response>
        /// <response code="412">Pre condition validation.</response>
        /// <response code="500">Internal server error.</response>

        [HttpPost]
        [ProducesResponseType(typeof(CreateCustomerCommandResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(PreConditionResponse), StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody]CreateCustomerCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                if (!result.Success)
                {
                    if (result.StatusCode == HttpStatusCode.PreconditionFailed)
                    {
                        return StatusCode(StatusCodes.Status412PreconditionFailed, PreConditionResponse.New(result.Message, result.Notifications));
                    }
                }

                return Created("api/Customers", result.Value);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Request Error");
            }

        }
    }
}