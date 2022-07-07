using CM.Infrastructure.Entities.Contracts;
using CM.Infrastructure.Repositories.Specifications;

namespace CM.Application.Contracts.GetAllContracts.Filters
{
    public abstract class FilterComponent
    {
        public abstract Specification<Contract> ApplySpecs();
    }
}
