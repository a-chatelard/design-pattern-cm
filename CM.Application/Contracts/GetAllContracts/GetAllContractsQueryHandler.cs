using CM.API.Models.Results.Contracts;
using CM.Application.Contracts.GetAllContracts.Filters;
using CM.Infrastructure.Repositories;
using MediatR;

namespace CM.Application.Contracts.GetAllContracts
{
    public class GetAllContractsQueryHandler : IRequestHandler<GetAllContractsQuery, IEnumerable<ContractDTO>>
    {
        private readonly IContractRepository _contractRepository;

        public GetAllContractsQueryHandler(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public async Task<IEnumerable<ContractDTO>> Handle(GetAllContractsQuery request, CancellationToken cancellationToken)
        {
            FilterComponent filter = new BaseFilterComponent();
            var filterDecorator = new FilterDecorator(filter);
            
            if (request.ContractTypeFilter.HasValue)
            {
                filterDecorator = new TypeFilterDecorator(filterDecorator, request.ContractTypeFilter.Value);
            }

            if (request.DailyRateFilter.HasValue)
            {
                if (request.DailyRateComparatorFilter.HasValue)
                {
                    filterDecorator = new DailyRateComparatorFilterDecorator(filterDecorator,
                        request.DailyRateComparatorFilter.Value, request.DailyRateFilter.Value);
                }
                else
                {
                    filterDecorator = new DailyRateFilterDecorator(filter, request.DailyRateFilter.Value);
                }

            }

            var result = await _contractRepository.GetContractsBySpecs(filterDecorator.ApplySpecs());

            return result.Select(c => new ContractDTO(c));
        }
    }
}
