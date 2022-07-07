using CM.Infrastructure.Entities.Base;
using CM.Infrastructure.Entities.Contracts.ContractStates;
using CM.Infrastructure.Entities.ContractStates;
using CM.Infrastructure.Entities.DTO;

namespace CM.Infrastructure.Entities.Contracts;

public class Contract : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public double DailyRate { get; set; }
    public TimeSpan DailyWorkTime { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public Address? TeleworkingAddress { get; set; }

    public ContractType Type { get; set; }

    public ContractState State { get; set; } = new CreatedState();

    public Contract() {}
}