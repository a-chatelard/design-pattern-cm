using CM.Infrastructure.Entities.Contracts;
using CM.Infrastructure.Exceptions;
using CM.Infrastructure.Repositories;
using MediatR;

namespace CM.Application.Contracts.DeleteContract
{
    public class DeleteContractCommandHandler : IRequestHandler<DeleteContractCommand>
    {
        private readonly IContractRepository _contractRepository;

        public DeleteContractCommandHandler(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public async Task<Unit> Handle(DeleteContractCommand request, CancellationToken cancellationToken)
        {
            var contract = await _contractRepository.GetContractById(request.ContractId);

            if (contract == null)
            {
                throw new EntityNotFoundException<Contract>(request.ContractId);
            }

            await _contractRepository.DeleteContract(contract);

            return Unit.Value;
        }
    }
}
