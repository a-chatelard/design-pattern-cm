using CM.Infrastructure.Entities.Base;
using CM.Infrastructure.Entities.ContractStates;

namespace CM.Infrastructure.Entities;

public class Contract : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public double DailyRate { get; set; }
    public TimeSpan WeeklyWorkTime { get; set; }

    public ContractState State { get; set; } = new CreatedState();

    public User User { get; set; } = default!;
    public Guid UserId { get; set; } = default!;

    public Contract(string title, string description, double dailyRate, TimeSpan weeklyWorkTime)
    {
        Title = title;
        Description = description;
        DailyRate = dailyRate;
        WeeklyWorkTime = weeklyWorkTime;
    }

    public Contract ShallowCopy()
    {
        var contract = new Contract(Title, Description, DailyRate, WeeklyWorkTime);

        return contract;
    }
}