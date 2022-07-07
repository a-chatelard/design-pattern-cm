using CM.Infrastructure.Context;
using CM.Infrastructure.Entities.Contracts;
using CM.Infrastructure.Repositories.Specifications;
using Microsoft.EntityFrameworkCore;

namespace CM.Infrastructure.Repositories;

public class ContractRepository : RepositoryBase<Contract>, IContractRepository
{
    public ContractRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task CreateContract(Contract contract)
    {
        await CreateAsync(contract);
    }

    public async Task<List<Contract>> GetContractsBySpecs(Specification<Contract> specs)
    {
        return await GetAllBySpecsAsync(specs);
    }

    public async Task<List<Contract>> GetAllContracts()
    {
        return await GetAll().ToListAsync();
    }

    public async Task<Contract?> GetContractBySpecs(Specification<Contract> specs)
    {
        return await GetSingleBySpecsAsync(specs);
    }

    public async Task<Contract?> GetContractById(Guid contractId)
    {
        return await GetAll()
            .SingleOrDefaultAsync(c => c.Id == contractId);
    }

    public async Task UpdateContract(Contract contract)
    {
        await UpdateAsync(contract);
    }

    public async Task DeleteContract(Contract contract)
    {
        await DeleteAsync(contract);
    }
}