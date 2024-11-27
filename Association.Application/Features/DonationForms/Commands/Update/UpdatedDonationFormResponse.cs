namespace Association.Application.Features.DonationForms.Commands.Update;

public record UpdatedDonationFormResponse(
    Guid Id, 
    Guid DonorId, 
    Guid DonationCategoryId, 
    decimal TotalPrice
);
