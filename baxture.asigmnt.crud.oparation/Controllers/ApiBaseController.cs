using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace baxture.asigmnt.crud.oparation.Controllers
{
    [ApiController]
    public abstract class ApiBaseController : ControllerBase
    {
        protected readonly IMapper mapper;
        protected readonly ILogger logger;
        protected readonly IMediator mediator;

        protected ApiBaseController(ILogger<ApiBaseController> logger, IMapper mapper, IMediator mediator)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)) ;
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
    }
}
