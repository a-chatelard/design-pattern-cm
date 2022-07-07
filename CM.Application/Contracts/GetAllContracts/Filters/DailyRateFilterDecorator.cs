using CM.Infrastructure.Entities.Contracts;
using CM.Infrastructure.Repositories.Specifications;
using CM.Infrastructure.Repositories.Specifications.Contracts;

namespace CM.Application.Contracts.GetAllContracts.Filters
{
    public class DailyRateFilterDecorator : FilterDecorator
    {
        private readonly double _dailyRate;

        public DailyRateFilterDecorator(FilterComponent component, double dailyRate) : base(component)
        {
            _dailyRate = dailyRate;
        }

        public override Specification<Contract> ApplySpecs()
        {
            return base.ApplySpecs().And(new ContractDailyRateSpecification(_dailyRate));
        }
    }
}
