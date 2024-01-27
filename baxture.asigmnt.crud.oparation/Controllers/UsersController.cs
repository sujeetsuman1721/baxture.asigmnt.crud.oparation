using AutoMapper;
using baxture.asigmnt.crud.oparation.Controllers;
using baxture.asigmnt.crud.oparation.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace baxture.asigmnt.crud.oparation.UsersController
{
    [Route("v1/users")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController : ApiBaseController
    {
        public UsersController(ILogger logger, IMapper mapper, IMediator mediator) : base(logger, mapper, mediator)
        {

        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(RegisterUser), 201)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUser registerUser)
        {

            return Ok(registerUser);

        }
    }
}
