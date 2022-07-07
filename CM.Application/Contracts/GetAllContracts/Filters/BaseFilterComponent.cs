using CM.Infrastructure.Entities.Contracts;
using CM.Infrastructure.Repositories.Specifications;
using CM.Infrastructure.Repositories.Specifications.Contracts;

namespace CM.Application.Contracts.GetAllContracts.Filters
{
    public class BaseFilterComponent : FilterComponent
    {
        public override Specification<Contract> ApplySpecs()
        {
            return new ContractSpecification();
        }
    }
}
