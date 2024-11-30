namespace Association.Application.Features.DonationForms.Queries.GetById;
public record GetByIdDonationFormDto(
    Guid Id,
    Guid DonorId,
    Guid DonationCategoryId,
    decimal TotalPrice,
    DateTime CreateDate
);
