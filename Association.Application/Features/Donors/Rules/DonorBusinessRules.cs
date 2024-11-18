using Association.Application.Common;
using Association.Application.Services.Donors;
using Association.Core.Entities;
using Association.Core.Exceptions;

namespace Association.Application.Features.Donors.Rules;

public class DonorBusinessRules : BaseBusinessRules
{
    private readonly IDonorService _donorService;

    public DonorBusinessRules(IDonorService donorService)
    {
        _donorService = donorService;
    }

    private async Task throwBusinessException(string erorCode, string message, string solution)
    {
        throw new BusinessException(erorCode, message, solution);
    }

    public async Task CheckIfEmailExists(Donor donor)
    {
        var donorByEmail = await _donorService.AnyAsync(predicate: d => d.Email == donor.Email);

        if (donorByEmail)
        {
            await throwBusinessException("DonorEmailExists", "Bu e-postaya sahip bağışçı zaten mevcut", "Lütfen farklı bir e-posta adresi giriniz");
        }
    }

    public async Task CheckIfDonorExists(Donor donor)
    {
        var donorExists = await _donorService.AnyAsync(predicate: d => d.Id == donor.Id);
        if (!donorExists)
        {
            await throwBusinessException("DonorExists", "Bu bağışçı mevcut değildir.", "");
        }
    }
}
