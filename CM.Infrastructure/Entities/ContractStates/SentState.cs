using CM.Infrastructure.Exceptions;

namespace CM.Infrastructure.Entities.ContractStates;

public class SentState : ContractState
{
    public override void Sign()
    {
        Contract.State = new SignedState();
    }

    public override void Send()
    {
        throw new WorkflowException("The contract has already been sent.");
    }

    public override void Deny()
    {
        Contract.State = new DeniedState();
    }

    public override void Close()
    {
        throw new WorkflowException("Cannot close the contract when its state is sent.");
    }

    public override string ToString()
    {
        return "SENT";
    }
}