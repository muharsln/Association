using Association.Application.Features.DonationCategories.Commands.Create;
using Association.Application.Features.DonationCategories.Commands.Delete;
using Association.Application.Features.DonationCategories.Commands.Update;
using Association.Application.Features.DonationCategories.Queries.GetById;
using Association.Application.Features.DonationCategories.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Association.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DonationCategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public DonationCategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost] // POST: api/DonationCategories
    public async Task<IActionResult> Post([FromBody] CreateDonationCategoryCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")] // DELETE: api/DonationCategories/5
    public async Task<IActionResult> Delete(Guid id)
    {
        DeleteDonationCategoryCommand command = new(id);
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("{id}")] // PUT: api/DonationCategories/5
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateDonationCategoryCommand command)
    {
        command.Id = id;
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpGet] // GET: api/DonationCategories
    public async Task<IActionResult> Get()
    {
        GetListDonationCategoryQuery query = new();
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("{id}")] // GET: api/DonationCategories/5
    public async Task<IActionResult> Get(Guid id)
    {
        GetByIdDonationCategoryQuery query = new(id);
        var response = await _mediator.Send(query);
        return Ok(response);
    }
}
