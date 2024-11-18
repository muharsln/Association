using Association.WebAPI.Context;
using Association.WebAPI.Controllers;
using Association.WebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;

namespace Association.WebAPI.Tests;

public class DonorsControllerTests
{
    private readonly Mock<AppDbContext> _mockContext;
    private readonly DonorsController _controller;
    private readonly List<Donor> _donors;

    public DonorsControllerTests()
    {
        _mockContext = new Mock<AppDbContext>();
        _controller = new DonorsController(_mockContext.Object);

        _donors = new List<Donor>
            {
                new Donor { Id = Guid.NewGuid(), Name = "John", Surname = "Doe", Email = "john.doe@example.com", Phone = "1234567890", Location = "Location1", IsActive = true },
                new Donor { Id = Guid.NewGuid(), Name = "Jane", Surname = "Doe", Email = "jane.doe@example.com", Phone = "0987654321", Location = "Location2", IsActive = true }
            };

        var mockSet = new Mock<DbSet<Donor>>();
        mockSet.As<IQueryable<Donor>>().Setup(m => m.Provider).Returns(_donors.AsQueryable().Provider);
        mockSet.As<IQueryable<Donor>>().Setup(m => m.Expression).Returns(_donors.AsQueryable().Expression);
        mockSet.As<IQueryable<Donor>>().Setup(m => m.ElementType).Returns(_donors.AsQueryable().ElementType);
        mockSet.As<IQueryable<Donor>>().Setup(m => m.GetEnumerator()).Returns(_donors.AsQueryable().GetEnumerator());

        mockSet.Setup(m => m.FindAsync(It.IsAny<Guid>())).ReturnsAsync((Guid id) => _donors.FirstOrDefault(d => d.Id == id));

        _mockContext.Setup(c => c.Donors).Returns(mockSet.Object);
    }

    [Fact]
    public async Task GetDonors_ReturnsAllDonors()
    {
        var result = await _controller.GetDonors();
        var actionResult = Assert.IsType<ActionResult<IEnumerable<Donor>>>(result);
        var returnValue = Assert.IsType<List<Donor>>(actionResult.Value);
        Assert.Equal(2, returnValue.Count);
    }

    [Fact]
    public async Task GetDonor_ReturnsDonor()
    {
        var donorId = _donors[0].Id;
        var result = await _controller.GetDonor(donorId);
        var actionResult = Assert.IsType<ActionResult<Donor>>(result);
        var returnValue = Assert.IsType<Donor>(actionResult.Value);
        Assert.Equal(donorId, returnValue.Id);
    }

    [Fact]
    public async Task GetDonor_ReturnsNotFound()
    {
        var result = await _controller.GetDonor(Guid.NewGuid());
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task PostDonor_CreatesDonor()
    {
        var newDonor = new Donor { Name = "New", Surname = "Donor", Email = "new.donor@example.com", Phone = "1112223333", Location = "Location3", IsActive = true };
        var result = await _controller.PostDonor(newDonor);
        var actionResult = Assert.IsType<ActionResult<Donor>>(result);
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
        var returnValue = Assert.IsType<Donor>(createdAtActionResult.Value);
        Assert.Equal(newDonor.Name, returnValue.Name);
    }

    [Fact]
    public async Task PutDonor_UpdatesDonor()
    {
        var donorId = _donors[0].Id;
        var updatedDonor = new Donor { Id = donorId, Name = "Updated", Surname = "Donor", Email = "updated.donor@example.com", Phone = "1112223333", Location = "Location1", IsActive = true };
        var result = await _controller.PutDonor(donorId, updatedDonor);
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task PutDonor_ReturnsNotFound()
    {
        var result = await _controller.PutDonor(Guid.NewGuid(), new Donor());
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task DeleteDonor_DeletesDonor()
    {
        var donorId = _donors[0].Id;
        var result = await _controller.DeleteDonor(donorId);
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task DeleteDonor_ReturnsNotFound()
    {
        var result = await _controller.DeleteDonor(Guid.NewGuid());
        Assert.IsType<NotFoundResult>(result);
    }
}
