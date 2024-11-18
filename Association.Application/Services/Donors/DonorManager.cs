using Association.Application.Repositories;
using Association.Core.Entities;
using System.Linq.Expressions;

namespace Association.Application.Services.Donors;
public class DonorManager : IDonorService
{
    private readonly IDonorRepository _donorRepository;

    public DonorManager(IDonorRepository donorRepository)
    {
        _donorRepository = donorRepository;
    }

    public async Task<Donor> AddAsync(Donor entity)
    {
        Donor addedDonor = await _donorRepository.AddAsync(entity);
        return addedDonor;
    }

    public async Task<bool> AnyAsync(Expression<Func<Donor, bool>> predicate)
    {
        var result = await _donorRepository.AnyAsync(predicate);
        return result;
    }

    public async Task<Donor> DeleteAsync(Donor entity)
    {
        Donor deletedDonor = await _donorRepository.DeleteAsync(entity);
        return deletedDonor;
    }

    public async Task<Donor> GetAsync(Expression<Func<Donor, bool>> predicate)
    {
        Donor? donor = await _donorRepository.GetAsync(predicate);

        return donor;
    }

    public async Task<ICollection<Donor>> GetListAsync(Expression<Func<Donor, bool>>? predicate = null)
    {
        ICollection<Donor> donors = await _donorRepository.GetListAsync(predicate);
        return donors;
    }

    public async Task<Donor> UpdateAsync(Donor entity)
    {
        Donor updatedDonor = await _donorRepository.UpdateAsync(entity);
        return updatedDonor;
    }
}
