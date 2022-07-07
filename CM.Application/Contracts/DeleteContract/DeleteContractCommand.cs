using MediatR;

namespace CM.Application.Contracts.DeleteContract;

public class DeleteContractCommand : IRequest
{
    public Guid ContractId { get; }

    public DeleteContractCommand(Guid contractId)
    {
        ContractId = contractId;
    }
}