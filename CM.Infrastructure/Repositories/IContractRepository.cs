using CM.Infrastructure.Entities.Contracts;
using CM.Infrastructure.Repositories.Specifications;


namespace CM.Infrastructure.Repositories;

public interface IContractRepository
{
    Task CreateContract(Contract contract);

    Task<List<Contract>> GetContractsBySpecs(Specification<Contract> specs);

    Task<List<Contract>> GetAllContracts();

    Task<Contract?> GetContractBySpecs(Specification<Contract> specs);
    
    Task<Contract?> GetContractById(Guid contractId);
    
    Task UpdateContract(Contract contract);
    
    Task DeleteContract(Contract contract);
}