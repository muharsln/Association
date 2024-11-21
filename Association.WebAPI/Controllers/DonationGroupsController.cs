using Association.Application.Features.DonationGroups.Commands.Create;
using Association.Application.Features.DonationGroups.Commands.Delete;
using Association.Application.Features.DonationGroups.Commands.Update;
using Association.Application.Features.DonationGroups.Queries.GetById;
using Association.Application.Features.DonationGroups.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Association.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DonationGroupsController : ControllerBase
{
    private readonly IMediator _mediator;
    public DonationGroupsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost] // POST: api/DonationGroups
    public async Task<IActionResult> CreateDonationGroup([FromBody] CreateDonationGroupCommand command)
    {
        CreatedDonationGroupResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpGet] // GET: api/DonationGroups
    public async Task<IActionResult> GetDonationGroups()
    {
        GetListDonationGroupQuery query = new();
        IEnumerable<GetListDonationGroupDto> donationGroups = await _mediator.Send(query);
        return Ok(donationGroups);
    }

    [HttpGet("{id}")] // GET: api/DonationGroups/5
    public async Task<IActionResult> GetDonationGroupById(Guid id)
    {
        GetByIdDonationGroupQuery query = new(id);
        GetByIdDonationGroupDto donationGroup = await _mediator.Send(query);
        return Ok(donationGroup);
    }

    [HttpPut("{id}")] // PUT: api/DonationGroups/5
    public async Task<IActionResult> UpdateDonationGroup(Guid id, [FromBody] UpdateDonationGroupCommand command)
    {
        command.Id = id;
        UpdatedDonationGroupResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")] // DELETE: api/DonationGroups/5
    public async Task<IActionResult> DeleteDonationGroup(Guid id)
    {
        DeleteDonationGroupCommand command = new(id);
        DeletedDonationGroupResponse response = await _mediator.Send(command);
        return Ok(response);
    }
}
