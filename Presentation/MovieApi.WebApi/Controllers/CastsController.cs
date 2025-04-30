using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CastsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult CastList()
        {
            var values = _mediator.Send(new GetCastQuery());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCast(CreateCastCommand command)
        {
            _mediator.Send(command);
            return Ok("Ekleme işlemi başarılı.");
        }

        [HttpDelete]
        public IActionResult DeleteCast(int id)
        {
            _mediator.Send(new RemoveCastCommand(id));
            return Ok("Silme işlemi başarılı.");
        }

        [HttpPut]
        public IActionResult UpdateCast(UpdateCastCommand command)
        {
            _mediator.Send(command);
            return Ok("Güncelleme işlemi başarılı.");
        }

        [HttpGet("GetCast")]
        public IActionResult GetCast(int id)
        {
            var value = _mediator.Send(new GetCastByIdQuery(id));
            return Ok(value);
        }
    }
}
