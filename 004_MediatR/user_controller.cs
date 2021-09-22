using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace 004_MediatR
{
    public class UsersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{id}")]
        public async Task<Order> Get(string id)
        {
            var user = await _mediator.Send(new GetUserQuery(id));
            if user == null {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
