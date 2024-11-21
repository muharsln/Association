using Association.Application.Features.IntentionTypes.Commands.Create;
using Association.Application.Features.IntentionTypes.Commands.Delete;
using Association.Application.Features.IntentionTypes.Commands.Update;
using Association.Application.Features.IntentionTypes.Queries.GetById;
using Association.Application.Features.IntentionTypes.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Association.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class IntentionTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public IntentionTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost] // POST: api/IntentionTypes
    public async Task<IActionResult> CreateIntentionType([FromBody] CreateIntentionTypeCommand command)
    {
        CreatedIntentionTypeResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpGet] // GET: api/IntentionTypes
    public async Task<IActionResult> GetIntentionTypes()
    {
        GetListIntentionTypeQuery query = new();
        IEnumerable<GetListIntentionTypeDto> intentionTypes = await _mediator.Send(query);
        return Ok(intentionTypes);
    }

    [HttpGet("{id}")] // GET: api/IntentionTypes/5
    public async Task<IActionResult> GetIntentionTypeById(Guid id)
    {
        GetByIdIntentionTypeQuery query = new(id);
        GetByIdIntentionTypeDto intentionType = await _mediator.Send(query);
        return Ok(intentionType);
    }

    [HttpDelete("{id}")] // DELETE: api/IntentionTypes/5
    public async Task<IActionResult> DeleteIntentionType(Guid id)
    {
        DeleteIntentionTypeCommand command = new(id);
        DeletedIntentionTypeResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("{id}")] // PUT: api/IntentionTypes/5
    public async Task<IActionResult> UpdateIntentionType(Guid id, [FromBody] UpdateIntentionTypeCommand command)
    {
        command.Id = id;
        UpdatedIntentionTypeResponse response = await _mediator.Send(command);
        return Ok(response);
    }
}
