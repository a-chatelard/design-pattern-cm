using CM.API.Models.Results.Contracts;
using CM.Infrastructure.Entities.Contracts;
using CM.Infrastructure.Exceptions;
using CM.Infrastructure.Repositories;
using MediatR;

namespace CM.Application.Contracts.GetContractDetails
{
    public class GetContractDetailsQueryHandler : IRequestHandler<GetContractDetailsQuery, ContractDTO>
    {
        private readonly IContractRepository _contractRepository;

        public GetContractDetailsQueryHandler(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }


        public async Task<ContractDTO> Handle(GetContractDetailsQuery request, CancellationToken cancellationToken)
        {
            var contract = await _contractRepository.GetContractById(request.ContractId);

            if (contract == null)
            {
                throw new EntityNotFoundException<Contract>(request.ContractId);
            }

            return new ContractDTO(contract);
        }
    }
}
