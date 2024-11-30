using Association.Application.Features.DonationShares.Commands.Create;
using Association.Application.Features.DonationShares.Commands.Delete;
using Association.Application.Features.DonationShares.Commands.Update;
using Association.Application.Features.DonationShares.Queries.GetById;
using Association.Application.Features.DonationShares.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Association.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DonationSharesController(IMediator mediator) : ControllerBase
{
    [HttpGet] // GET api/donationShares
    public async Task<IActionResult> GetDonationShares()
    {
        GetListDonationShareQuery query = new();
        var response = await mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("{id}")] // GET api/donationShares/5
    public async Task<IActionResult> GetDonationShare(Guid id)
    {
        GetByIdDonationShareQuery query = new(id);
        var response = await mediator.Send(query);
        return Ok(response);
    }

    [HttpPost] // POST api/donationShares
    public async Task<IActionResult> CreateDonationShare([FromBody] CreateDonationShareCommand command)
    {
        var response = await mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("{id}")] // PUT api/donationShares/5
    public async Task<IActionResult> UpdateDonationShare(Guid id, [FromBody] UpdateDonationShareCommand command)
    {
        command.Id = id;
        var response = await mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")] // DELETE api/donationShares/5
    public async Task<IActionResult> DeleteDonationShare(Guid id)
    {
        DeleteDonationShareCommand command = new(id);
        var response = await mediator.Send(command);
        return Ok(response);
    }
}
