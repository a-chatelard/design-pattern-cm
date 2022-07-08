namespace CM.API.Models.Requests
{
    public class ContractRequestDTO
    {
        public TimeSpan DailyWorkTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double DailyRate { get; set; }
        public AddressRequestDTO Address { get; set; }

        public ContractRequestDTO(TimeSpan dailyWorkTime, DateTime startDate, DateTime? endDate, double dailyRate, AddressRequestDTO address)
        {
            DailyWorkTime = dailyWorkTime;
            StartDate = startDate;
            EndDate = endDate;
            DailyRate = dailyRate;
            Address = address;
        }
    }
}
