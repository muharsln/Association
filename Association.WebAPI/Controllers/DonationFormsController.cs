using MediatR;
using Microsoft.AspNetCore.Mvc;
using Association.Application.Features.DonationForms.Commands.Create;
using Association.Application.Features.DonationForms.Queries.GetList;
using Association.Application.Features.DonationForms.Queries.GetById;
using Association.Application.Features.DonationForms.Commands.Update;
using Association.Application.Features.DonationForms.Commands.Delete;

namespace Association.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DonationFormsController(IMediator mediator) : ControllerBase
{
    [HttpGet] // GET api/donationForms
    public async Task<IActionResult> GetDonationForms()
    {
        var query = new GetListDonationFormQuery();
        var response = await mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("{id}")] // GET api/donationForms/5
    public async Task<IActionResult> GetDonationFormById(Guid id)
    {
        GetByIdDonationFormQuery query = new(id);
        var response = await mediator.Send(query);
        return Ok(response);
    }

    [HttpPost] // POST api/donationForms
    public async Task<IActionResult> CreateDonationForm([FromBody] CreateDonationFormCommand command)
    {
        var response = await mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("{id}")] // PUT api/donationForms/5
    public async Task<IActionResult> UpdateDonationForm(Guid id, [FromBody] UpdateDonationFormCommand command)
    {
        command.Id = id;
        var response = await mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")] // DELETE api/donationForms/5
    public async Task<IActionResult> DeleteDonationForm(Guid id)
    {
        DeleteDonationFormCommand command = new(id);
        var response = await mediator.Send(command);
        return Ok(response);
    }
}
