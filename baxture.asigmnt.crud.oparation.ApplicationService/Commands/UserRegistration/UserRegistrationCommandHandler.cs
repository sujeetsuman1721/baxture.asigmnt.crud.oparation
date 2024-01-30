using AutoMapper;
using baxture.asigmnt.crud.oparation.Application.Dtos;
using baxture.asigmnt.crud.oparation.ApplicationService.ApplicationServices;
using baxture.asigmnt.crud.oparation.domain.Models;
using baxture.asigmnt.crud.oparation.domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baxture.asigmnt.crud.oparation.Application.Commands.UserRegistration
{

    public class UserRegistrationCommandHandler : IRequestHandler<UserRegistrationCommand, bool>
    {
        private readonly IUserServices userServices;
        private readonly IUserRepository userRepository ;
        private readonly IMapper mapper;
        private readonly ILogger<UserRegistrationCommandHandler> logger;
        //private readonly TenantConfiguration tenantConfiguration;
        private readonly IMediator mediator;

        public UserRegistrationCommandHandler(IUserServices userServices, IUserRepository userRepository, ILogger<UserRegistrationCommandHandler> logger, IMapper mapper, IMediator mediator)
        {
            this.mediator = mediator;
            this.userServices = userServices;
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.logger = logger;

        }
        public async Task<bool>Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
        {
           
            try
            {
                if (request == null || request.UserRegistrationDto == null)
                {
                    this.logger.LogInformation("Arguments cannot be null for creating a query.");
                    throw new ArgumentNullException(nameof(request));
                }
                RegisterUser registerUser = this.mapper.Map<RegisterUser>(request.UserRegistrationDto);
                var userUser = await this.userRepository.CreateUser(registerUser);
            }
            catch (Exception ex)
            {

            }

            return true ;
 
        }
    }
}
