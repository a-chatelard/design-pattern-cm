using CM.API.Models.Requests;
using CM.API.Models.Results.Contracts;
using CM.Infrastructure.Entities.Contracts;
using MediatR;

namespace CM.Application.Contracts.GetAllContracts
{
    public class GetAllContractsQuery : IRequest<IEnumerable<ContractDTO>>
    {
        public ContractType? ContractTypeFilter { get; }

        public double? DailyRateFilter { get; }

        public char? DailyRateComparatorFilter { get; }

        public GetAllContractsQuery(ContractFilterRequest? filters)
        {
            if (filters == null) return;
            if (Enum.TryParse<ContractType>(filters.ContractType, out var contractTypeParsed))
            {
                ContractTypeFilter = contractTypeParsed;
            }

            DailyRateFilter = filters.DailyRate;
            if (!DailyRateFilter.HasValue) return;
            switch (filters.DailyRateComparator)
            {
                case '<':
                case '>':
                case '=':
                    DailyRateComparatorFilter = filters.DailyRateComparator;
                    break;
            }
        }
    }
}
