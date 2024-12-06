using MediatrClone.API.Models;
using MediatrClone.API.Queries;
using MediatrClone.Library.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediatrClone.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class UserController : Controller
    {

        private readonly IMediator mediator;

        public UserController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet]
        public Task<UserViewModel> Get()
        {
            var x =  mediator.Send(new GetUserByIdQuery(10));
            return x;
        }
    }
}
