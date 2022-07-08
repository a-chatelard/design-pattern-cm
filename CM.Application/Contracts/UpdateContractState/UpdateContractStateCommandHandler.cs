using CM.API.Controllers;
using CM.API.Models.Results.Contracts;
using CM.Application.Exceptions;
using CM.Infrastructure.Entities.Contracts;
using CM.Infrastructure.Exceptions;
using CM.Infrastructure.Repositories;
using MediatR;

namespace CM.Application.Contracts.UpdateContractState
{
    public class UpdateContractStateCommandHandler : IRequestHandler<UpdateContractStateCommand, ContractDTO>
    {
        private readonly IContractRepository _contractRepository;

        public UpdateContractStateCommandHandler(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public async Task<ContractDTO> Handle(UpdateContractStateCommand request, CancellationToken cancellationToken)
        {
            var contract = await _contractRepository.GetContractById(request.ContractId);

            if (contract == null)
            {
                throw new EntityNotFoundException<Contract>(request.ContractId);
            }

            switch (request.State)
            {
                case "close":
                    contract.State.Close();
                    break;
                case "deny":
                    contract.State.Deny();
                    break;
                case "send":
                    contract.State.Send();
                    break;
                case "sign": 
                    contract.State.Sign();
                    break;
                default:
                    throw new CMApplicationException("Invalid action " + request.State + ".");
            }

            await _contractRepository.UpdateContract(contract);

            return new ContractDTO(contract);
        }
    }
}
