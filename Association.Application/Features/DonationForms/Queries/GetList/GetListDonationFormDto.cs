namespace Association.Application.Features.DonationForms.Queries.GetList;
public record GetListDonationFormDto(
    Guid Id,
    Guid DonorId,
    Guid DonationCategoryId,
    decimal TotalPrice,
    DateTime CreateDate
);
