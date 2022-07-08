namespace CM.API.Models.Requests
{
    public class ContractFilterRequest
    {
        /// <summary>
        ///  test
        /// </summary>
        public string? ContractType { get; set; }
        public double? DailyRate { get; set; }
        public char? DailyRateComparator { get; set; }
    }
}
