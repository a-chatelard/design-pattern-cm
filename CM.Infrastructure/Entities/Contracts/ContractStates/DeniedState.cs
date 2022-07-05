using CM.Infrastructure.Exceptions;

namespace CM.Infrastructure.Entities.ContractStates;

public class DeniedState : ContractState
{
    public override void Sign()
    {
        throw new WorkflowException("Cannot sign the contract when its state is denied.");
    }

    public override void Send()
    {
        throw new WorkflowException("Cannot send the contract when its state is denied.");
    }

    public override void Deny()
    {
        throw new WorkflowException("This contract is already denied.");
    }

    public override void Close()
    {
        throw new WorkflowException("Cannot close the contract when its state is denied.");
    }

    public override string ToString()
    {
        return "DENIED";
    }
}