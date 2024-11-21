using Association.Application.Features.DonationCategories.Rules;
using Association.Application.Services.DonationCategories;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationCategories.Commands.Delete;

public class DeleteDonationCategoryCommandHandler : IRequestHandler<DeleteDonationCategoryCommand, DeletedDonationCategoryResponse>
{
    private readonly IDonationCategoryService _donationCategoryService;
    private readonly IMapper _mapper;
    private readonly DonationCategoryBusinessRules _donationCategoryBusinessRules;

    public DeleteDonationCategoryCommandHandler(IDonationCategoryService donationCategoryService, IMapper mapper, DonationCategoryBusinessRules donationCategoryBusinessRules)
    {
        _donationCategoryService = donationCategoryService;
        _mapper = mapper;
        _donationCategoryBusinessRules = donationCategoryBusinessRules;
    }

    public async Task<DeletedDonationCategoryResponse> Handle(DeleteDonationCategoryCommand request, CancellationToken cancellationToken)
    {
        var donationCategory = _mapper.Map<DonationCategory>(request);

        await _donationCategoryBusinessRules.CheckIfIdExists(donationCategory);
        await _donationCategoryBusinessRules.CheckIfDonationCategoryHasDonationForms(donationCategory);
        await _donationCategoryBusinessRules.CheckIfDonationCategoryHasDonationOptions(donationCategory);

        await _donationCategoryService.DeleteAsync(donationCategory);

        return _mapper.Map<DeletedDonationCategoryResponse>(donationCategory);
    }
}
