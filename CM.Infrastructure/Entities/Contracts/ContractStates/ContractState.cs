using CM.Infrastructure.Entities.Contracts;

namespace CM.Infrastructure.Entities.ContractStates;

public abstract class ContractState
{
    public Contract Contract { get; protected set; } = default!;

    protected ContractState()
    {

    }

    public abstract void Sign();
    public abstract void Send();
    public abstract void Deny();
    public abstract void Close();

    public abstract override string ToString();

    public static ContractState FromString(string state)
    {
        return state switch
        {
            "CLOSED" => new ClosedState(),
            "CREATED" => new CreatedState(),
            "DENIED" => new DeniedState(),
            "SENT" => new SentState(),
            "SIGNED" => new SignedState(),
            _ => throw new InvalidCastException("Cannot create contract state of label " + state)
        };
    }
}