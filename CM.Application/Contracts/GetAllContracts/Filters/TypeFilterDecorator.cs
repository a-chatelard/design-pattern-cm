using CM.Infrastructure.Entities.Contracts;
using CM.Infrastructure.Repositories.Specifications;
using CM.Infrastructure.Repositories.Specifications.Contracts;

namespace CM.Application.Contracts.GetAllContracts.Filters
{
    public class TypeFilterDecorator : FilterDecorator
    {
        private readonly ContractType _contractType;

        public TypeFilterDecorator(FilterComponent component, ContractType contractType) : base(component)
        {
            _contractType = contractType;
        }

        public override Specification<Contract> ApplySpecs()
        {
            return base.ApplySpecs().And(new ContractTypeSpecification(_contractType));
        }
    }
}
