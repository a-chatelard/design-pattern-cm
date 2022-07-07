using CM.Infrastructure.Entities.Contracts;
using CM.Infrastructure.Repositories.Specifications;
using CM.Infrastructure.Repositories.Specifications.Contracts;

namespace CM.Application.Contracts.GetAllContracts.Filters
{
    public class DailyRateComparatorFilterDecorator : FilterDecorator
    {
        private readonly char _comparator;
        private readonly double _dailyRate;

        public DailyRateComparatorFilterDecorator(FilterComponent component, char comparator, double dailyRate) : base(component)
        {
            _comparator = comparator;
            _dailyRate = dailyRate;
        }

        public override Specification<Contract> ApplySpecs()
        {
            return _comparator switch
            {
                '>' => base.ApplySpecs().And(new ContractDailyRateSuperiorSpecification(_dailyRate)),
                '<' => base.ApplySpecs().And(new ContractDailyRateInferiorSpecification(_dailyRate)),
                _ => base.ApplySpecs()
            };
        }
    }
}
