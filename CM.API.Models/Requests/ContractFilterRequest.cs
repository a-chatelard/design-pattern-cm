namespace CM.API.Models.Requests
{
    public class ContractFilterRequest
    {
        public string? ContractType { get; set; }
        public double? DailyRate { get; set; }
        public char? DailyRateComparator { get; set; }
    }
}
