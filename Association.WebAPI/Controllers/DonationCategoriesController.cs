using MediatR;
using Microsoft.AspNetCore.Mvc;
using Association.Application.Features.DonationCategories.Queries.GetList;
using Association.Application.Features.DonationCategories.Queries.GetById;
using Association.Application.Features.DonationCategories.Commands.Create;
using Association.Application.Features.DonationCategories.Commands.Update;
using Association.Application.Features.DonationCategories.Commands.Delete;

namespace Association.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DonationCategoriesController(IMediator mediator) : ControllerBase
{
    [HttpGet] // GET: api/DonationCategories
    public async Task<IActionResult> GetDonationCategories()
    {
        GetListDonationCategoryQuery query = new();
        var response = await mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("{id}")] // GET: api/DonationCategories/5
    public async Task<IActionResult> GetDonationCategoryById(Guid id)
    {
        GetByIdDonationCategoryQuery query = new(id);
        var response = await mediator.Send(query);
        return Ok(response);
    }

    [HttpPost] // POST: api/DonationCategories
    public async Task<IActionResult> CreateDonationCategory([FromBody] CreateDonationCategoryCommand command)
    {
        var response = await mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("{id}")] // PUT: api/DonationCategories/5
    public async Task<IActionResult> UpdateDonationCategory(Guid id, [FromBody] UpdateDonationCategoryCommand command)
    {
        command.Id = id;
        var response = await mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")] // DELETE: api/DonationCategories/5
    public async Task<IActionResult> DeleteDonationCategory(Guid id)
    {
        DeleteDonationCategoryCommand command = new(id);
        var response = await mediator.Send(command);
        return Ok(response);
    }
}
