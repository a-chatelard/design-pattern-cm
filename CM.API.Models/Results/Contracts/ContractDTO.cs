using CM.Infrastructure.Entities.Contracts;

namespace CM.API.Models.Results.Contracts
{
    public class ContractDTO
    {
        public string Title { get; }
        public string Description { get; }
        public double DailyRate { get; }
        public TimeSpan DailyWorkTime { get; }
        public DateTime StartDate { get; }
        public DateTime? EndDate { get; }
        public string State { get; }
        public string Type { get; }


        public ContractDTO(Contract contract)
        {
            Title = contract.Title;
            Description = contract.Description;
            DailyRate = contract.DailyRate;
            DailyWorkTime = contract.DailyWorkTime;
            StartDate = contract.StartDate;
            EndDate = contract.EndDate;
            State = contract.State.ToString();
            Type = contract.Type.ToString();
        }
    }
}
