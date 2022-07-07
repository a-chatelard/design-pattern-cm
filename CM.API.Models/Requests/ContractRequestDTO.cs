namespace CM.API.Models.Requests
{
    public class ContractRequestDTO
    {
        public TimeSpan DaiyWorkTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double DailyRate { get; set; }
        public AddressRequestDTO Address { get; set; }

        public ContractRequestDTO(TimeSpan daiyWorkTime, DateTime startDate, DateTime? endDate, double dailyRate, AddressRequestDTO address)
        {
            DaiyWorkTime = daiyWorkTime;
            StartDate = startDate;
            EndDate = endDate;
            DailyRate = dailyRate;
            Address = address;
        }
    }
}
