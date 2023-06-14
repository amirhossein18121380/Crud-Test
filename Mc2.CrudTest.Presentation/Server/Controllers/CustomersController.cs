using AutoMapper;
using Mc2.CrudTest.Presentation.Server.Customers.Features.AddCustomer;
using Mc2.CrudTest.Presentation.Server.Customers.Features.GettingAllCustomersByPage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public CustomersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        /// <summary>
        /// Creates a new user account
        /// </summary>
        ///
        /// <remarks>
        /// Validates given user credentials and creates a new user account
        /// </remarks>
        /// 
        /// <param name="credentials">
        /// Specifies the user credentials to be used for the new user account
        /// </param>
        /// 
        /// <param name="cancellationToken">
        /// Notifies asynchronous operations to cancel ongoing work and release resources
        /// </param>
        /// 
        /// <returns>
        /// Location of where to fetch the created user data ('Location' header)
        /// </returns>
        ///
        /// <response code="201">
        /// Contains the location of where to fetch the created user data inside the 'Location' header
        /// </response>
        ///
        /// <response code="400">
        /// Provided user credentials are in an invalid format
        /// </response>
        ///
        /// <response code="403">
        /// There is already a user with provided userName or email. The user is not allowed to sign up with provided credentials
        /// </response>
        ///
        /// <response code="500">
        /// An unexpected error occurred on the server
        /// </response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddCustomer(AddCustomerRequestDto request)
        {
            var command = _mapper.Map<AddCustomer>(request);
            var result = await _mediator.Send(command);
            var response = new AddCustomerResponseDto(result.Id);
            return Ok(response);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCustomers(GetCustomersByPageRequestDto request)
        {
            var command = _mapper.Map<GetCustomersByPage>(request);
            var result = await _mediator.Send(command);
            var response = _mapper.Map<GetCustomersByPageResponseDto>(result);
            return Ok(response);
        }
    }
}