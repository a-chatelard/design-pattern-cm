using CM.Infrastructure.Entities.ContractStates;
using CM.Infrastructure.Exceptions;

namespace CM.Infrastructure.Entities.Contracts.ContractStates;

public class CreatedState : ContractState
{
    public override void Sign()
    {
        throw new WorkflowException("Cannot sign the contract when its state is created.");
    }

    public override void Send()
    {
        Contract.State = new SentState();
    }

    public override void Deny()
    {
        throw new WorkflowException("Cannot deny the contract when its state is created.");
    }

    public override void Close()
    {
        Contract.State = new ClosedState();
    }

    public override string ToString()
    {
        return "CREATED";
    }
}