using CM.API.Models.Results.Contracts;
using MediatR;

namespace CM.API.Controllers;

public class UpdateContractStateCommand : IRequest<ContractDTO>
{
    public Guid ContractId { get; }
    public string State { get; }

    public UpdateContractStateCommand(Guid contractId, string state)
    {
        ContractId = contractId;
        State = state;
    }
}