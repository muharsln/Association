using MediatR;
using Microsoft.AspNetCore.Mvc;
using Association.Application.Features.IntentionTypes.Queries.GetList;
using Association.Application.Features.IntentionTypes.Queries.GetById;
using Association.Application.Features.IntentionTypes.Commands.Create;
using Association.Application.Features.IntentionTypes.Commands.Update;
using Association.Application.Features.IntentionTypes.Commands.Delete;

namespace Association.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class IntentionTypesController(IMediator mediator) : ControllerBase
{
    [HttpGet] // GET: api/IntentionTypes
    public async Task<IActionResult> GetIntentionTypes()
    {
        GetListIntentionTypeQuery query = new();
        IEnumerable<GetListIntentionTypeDto> intentionTypes = await mediator.Send(query);
        return Ok(intentionTypes);
    }

    [HttpGet("{id}")] // GET: api/IntentionTypes/5
    public async Task<IActionResult> GetIntentionTypeById(Guid id)
    {
        GetByIdIntentionTypeQuery query = new(id);
        GetByIdIntentionTypeDto intentionType = await mediator.Send(query);
        return Ok(intentionType);
    }

    [HttpPost] // POST: api/IntentionTypes
    public async Task<IActionResult> CreateIntentionType([FromBody] CreateIntentionTypeCommand command)
    {
        CreatedIntentionTypeResponse response = await mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("{id}")] // PUT: api/IntentionTypes/5
    public async Task<IActionResult> UpdateIntentionType(Guid id, [FromBody] UpdateIntentionTypeCommand command)
    {
        command.Id = id;
        UpdatedIntentionTypeResponse response = await mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")] // DELETE: api/IntentionTypes/5
    public async Task<IActionResult> DeleteIntentionType(Guid id)
    {
        DeleteIntentionTypeCommand command = new(id);
        DeletedIntentionTypeResponse response = await mediator.Send(command);
        return Ok(response);
    }
}
