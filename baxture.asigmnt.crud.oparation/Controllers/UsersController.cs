using AutoMapper;
using baxture.asigmnt.crud.oparation.Application.Commands.UserRegistration;
using baxture.asigmnt.crud.oparation.Application.Dtos;
using baxture.asigmnt.crud.oparation.Controllers;
using baxture.asigmnt.crud.oparation.domain.comman;
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
        public UsersController(ILogger<UsersController> logger, IMapper mapper, IMediator mediator) : base(logger, mapper, mediator)
        {

        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(RegisterUser), 201)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUser registerUser)
        {
            if (registerUser == null || string.IsNullOrWhiteSpace(registerUser.UserName) || string.IsNullOrWhiteSpace(registerUser.Password) )
            {
                ErrorModel model = new ErrorModel()
                {
                    Errorcode = nameof(ErrorCodes.OSDE002),
                    ErrorMessage = ErrorCodes.OSDE002
                };
                this.logger.LogInformation($"Missing required argument for the user creation request");
                return BadRequest(model) ;

            }
            UserRegistrationDto userRegistration = this.mapper.Map<RegisterUser, UserRegistrationDto>(registerUser);
            UserRegistrationCommand userRegistrationCommand = new (userRegistration);
            var response = await this.mediator.Send(userRegistrationCommand);

            return Ok(registerUser);

        }
    }
}
