using CM.Infrastructure.Exceptions;

namespace CM.Infrastructure.Entities.ContractStates;

public class SignedState : ContractState
{
    public override void Sign()
    {
        throw new WorkflowException("This contract is already signed.");
    }

    public override void Send()
    {
        throw new WorkflowException("Cannot send the contract when its state is signed");
    }

    public override void Deny()
    {
        throw new WorkflowException("Cannot deny the contract when its state is signed");

    }

    public override void Close()
    {
        Contract.State = new ClosedState();
    }

    public override string ToString()
    {
        return "SIGNED";
    }
}