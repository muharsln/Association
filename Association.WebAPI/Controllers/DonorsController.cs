using MediatR;
using Microsoft.AspNetCore.Mvc;
using Association.Application.Features.Donors.Queries.GetList;
using Association.Application.Features.Donors.Queries.GetById;
using Association.Application.Features.Donors.Commands.Create;
using Association.Application.Features.Donors.Commands.Update;
using Association.Application.Features.Donors.Commands.Delete;

namespace Association.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DonorsController(IMediator mediator) : ControllerBase
{
    [HttpGet] // GET: api/Donors
    public async Task<IActionResult> GetDonors()
    {
        GetListDonorQuery query = new();
        IEnumerable<GetListDonorDto> donors = await mediator.Send(query);
        return Ok(donors);
    }

    [HttpGet("{id}")] // GET: api/Donors/5
    public async Task<IActionResult> GetDonorById(Guid id)
    {
        GetByIdDonorQuery query = new(id);
        GetByIdDonorDto donor = await mediator.Send(query);
        return Ok(donor);
    }

    [HttpPost] // POST: api/Donors
    public async Task<IActionResult> CreateDonor([FromBody] CreateDonorCommand command)
    {
        CreatedDonorResponse response = await mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("{id}")] // PUT: api/Donors/5
    public async Task<IActionResult> UpdateDonor(Guid id, [FromBody] UpdateDonorCommand command)
    {
        command.Id = id;
        UpdatedDonorResponse response = await mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")] // DELETE: api/Donors/5
    public async Task<IActionResult> DeleteDonor(Guid id)
    {
        DeleteDonorCommand command = new(id);
        DeletedDonorResponse response = await mediator.Send(command);
        return Ok(response);
    }
}
