using MediatR;
using Microsoft.AspNetCore.Mvc;
using Association.Application.Features.DonationGroups.Queries.GetList;
using Association.Application.Features.DonationGroups.Queries.GetById;
using Association.Application.Features.DonationGroups.Commands.Create;
using Association.Application.Features.DonationGroups.Commands.Update;
using Association.Application.Features.DonationGroups.Commands.Delete;

namespace Association.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DonationGroupsController(IMediator mediator) : ControllerBase
{
    [HttpGet] // GET: api/DonationGroups
    public async Task<IActionResult> GetDonationGroups()
    {
        GetListDonationGroupQuery query = new();
        IEnumerable<GetListDonationGroupDto> donationGroups = await mediator.Send(query);
        return Ok(donationGroups);
    }

    [HttpGet("{id}")] // GET: api/DonationGroups/5
    public async Task<IActionResult> GetDonationGroupById(Guid id)
    {
        GetByIdDonationGroupQuery query = new(id);
        GetByIdDonationGroupDto donationGroup = await mediator.Send(query);
        return Ok(donationGroup);
    }

    [HttpPost] // POST: api/DonationGroups
    public async Task<IActionResult> CreateDonationGroup([FromBody] CreateDonationGroupCommand command)
    {
        CreatedDonationGroupResponse response = await mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("{id}")] // PUT: api/DonationGroups/5
    public async Task<IActionResult> UpdateDonationGroup(Guid id, [FromBody] UpdateDonationGroupCommand command)
    {
        command.Id = id;
        UpdatedDonationGroupResponse response = await mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")] // DELETE: api/DonationGroups/5
    public async Task<IActionResult> DeleteDonationGroup(Guid id)
    {
        DeleteDonationGroupCommand command = new(id);
        DeletedDonationGroupResponse response = await mediator.Send(command);
        return Ok(response);
    }
}
