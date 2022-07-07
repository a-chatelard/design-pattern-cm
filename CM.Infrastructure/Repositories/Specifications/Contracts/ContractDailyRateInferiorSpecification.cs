using CM.Infrastructure.Entities.Contracts;
using System.Linq.Expressions;

namespace CM.Infrastructure.Repositories.Specifications.Contracts
{
    public class ContractDailyRateInferiorSpecification : Specification<Contract>
    {
        private readonly double _dailyRate;

        public ContractDailyRateInferiorSpecification(double dailyRate)
        {
            _dailyRate = dailyRate;
        }

        public override Expression<Func<Contract, bool>> ToExpression()
        {
            return c => c.DailyRate < _dailyRate;
        }
    }
}
