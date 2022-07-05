using CM.Infrastructure.Exceptions;

namespace CM.Infrastructure.Entities.ContractStates;

public class ClosedState : ContractState
{
    public override void Sign()
    {
        throw new WorkflowException("Cannot sign the contract when its state is closed");
    }

    public override void Send()
    {
        throw new WorkflowException("Cannot send the contract when its state is closed");
    }

    public override void Deny()
    {
        throw new WorkflowException("Cannot sign the contract when its state is closed");
    }

    public override void Close()
    {
        throw new WorkflowException("Cannot sign the contract when its state is closed");
    }

    public override string ToString()
    {
        return "CLOSED";
    }
}