using CM.Infrastructure.Entities.Contracts;
using System.Linq.Expressions;

namespace CM.Infrastructure.Repositories.Specifications.Contracts
{
    public class ContractDailyRateSpecification : Specification<Contract>
    {
        private readonly double _dailyRate;

        public ContractDailyRateSpecification(double dailyRate)
        {
            _dailyRate = dailyRate;
        }

        public override Expression<Func<Contract, bool>> ToExpression()
        {
            return c => c.DailyRate > _dailyRate;
        }
    }
}
