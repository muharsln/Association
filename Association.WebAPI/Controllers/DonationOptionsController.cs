using Association.Application.Features.DonationOptions.Commands.Create;
using Association.Application.Features.DonationOptions.Commands.Delete;
using Association.Application.Features.DonationOptions.Commands.Update;
using Association.Application.Features.DonationOptions.Queries.GetById;
using Association.Application.Features.DonationOptions.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Association.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DonationOptionsController(IMediator mediator) : ControllerBase
{
    [HttpGet] // GET api/DonationOptions
    public async Task<IActionResult> GetDonationOptions()
    {
        GetListDonationOptionQuery query = new();
        var response = await mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("{id}")] // GET api/DonationOptions/5
    public async Task<IActionResult> GetDonationOptionById(Guid id)
    {
        GetByIdDonationOptionQuery query = new(id);
        var response = await mediator.Send(query);
        return Ok(response);
    }

    [HttpPost] // POST api/DonationOptions
    public async Task<IActionResult> CreateDonationOption([FromBody] CreateDonationOptionCommand command)
    {
        var response = await mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("{id}")] // PUT api/DonationOptions/5
    public async Task<IActionResult> UpdateDonationOption(Guid id, [FromBody] UpdateDonationOptionCommand command)
    {
        command.Id = id;
        var response = await mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")] // DELETE api/DonationOptions/5
    public async Task<IActionResult> DeleteDonationOption(Guid id)
    {
        DeleteDonationOptionCommand command = new(id);
        var response = await mediator.Send(command);
        return Ok(response);
    }
}
