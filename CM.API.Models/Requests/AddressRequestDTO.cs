namespace CM.API.Models.Requests
{
    public class AddressRequestDTO
    {
        public int Number { get; set; }
        public string Label { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
