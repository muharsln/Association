namespace Association.Application.Features.DonationForms.Commands.Create;
public record CreatedDonationFormResponse(
    Guid Id, 
    Guid DonorId, 
    Guid DonationCategoryId, 
    decimal TotalPrice, 
    DateTime CreateDate
);
