using CourseManagement.Application.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CourseManagement.API.Controllers
{
    public abstract class CrudApiController<
        TCreateCommand, TGetQuery, TGetAllQuery, TUpdateCommand, TDeleteCommand> : ApiController
        where TCreateCommand : IBaseRequest
        where TGetQuery : IIdRequest, IBaseRequest, new()
        where TGetAllQuery : IBaseRequest, new()
        where TUpdateCommand : IIdRequest, IBaseRequest
        where TDeleteCommand : IIdRequest, IBaseRequest, new()
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create(TCreateCommand request)
        {
            if (request == null)
                return BadRequest();

            return Ok(await Mediator.Send(request));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new TGetAllQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await Mediator.Send(new TGetQuery() { Id = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, TUpdateCommand request)
        {
            if (request == null)
                return BadRequest();

            if (id != request.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(request);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await Mediator.Send(new TDeleteCommand() { Id = id });
            return NoContent();
        }
    }
}