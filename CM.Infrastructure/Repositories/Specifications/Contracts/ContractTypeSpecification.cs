using CM.Infrastructure.Entities.Contracts;
using System.Linq.Expressions;

namespace CM.Infrastructure.Repositories.Specifications.Contracts
{
    public class ContractTypeSpecification : Specification<Contract>
    {
        private readonly ContractType _contractType;

        public ContractTypeSpecification(ContractType contractType)
        {
            _contractType = contractType;
        }

        public override Expression<Func<Contract, bool>> ToExpression()
        {
            return c => c.Type == _contractType;
        }
    }
}
