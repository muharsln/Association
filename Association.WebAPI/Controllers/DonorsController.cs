using Association.Application.Features.Donors.Commands.Create;
using Association.Application.Features.Donors.Commands.Delete;
using Association.Application.Features.Donors.Commands.Update;
using Association.Application.Features.Donors.Queries.GetById;
using Association.Application.Features.Donors.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Association.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DonorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DonorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost] // POST: api/Donors
    public async Task<IActionResult> CreateDonor([FromBody] CreateDonorCommand command)
    {
        CreatedDonorResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpGet] // GET: api/Donors
    public async Task<IActionResult> GetDonors()
    {
        GetListDonorQuery query = new();
        IEnumerable<GetListDonorDto> donors = await _mediator.Send(query);
        return Ok(donors);
    }

    [HttpGet("{id}")] // GET: api/Donors/5
    public async Task<IActionResult> GetDonorById(Guid id)
    {
        GetByIdDonorQuery query = new(id);
        GetByIdDonorDto donor = await _mediator.Send(query);
        return Ok(donor);
    }
    [HttpPut("{id}")] // PUT: api/Donors/5
    public async Task<IActionResult> UpdateDonor(Guid id, [FromBody] UpdateDonorCommand command)
    {
        command.Id = id;
        UpdatedDonorResponse response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpDelete("{id}")] // DELETE: api/Donors/5
    public async Task<IActionResult> DeleteDonor(Guid id)
    {
        DeleteDonorCommand command = new(id);
        DeletedDonorResponse response = await _mediator.Send(command);
        return Ok(response);
    }
}
