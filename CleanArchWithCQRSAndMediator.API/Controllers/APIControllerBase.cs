﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchWithCQRSAndMediator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class APIControllerBase : ControllerBase
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
