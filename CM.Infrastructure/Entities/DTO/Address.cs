namespace CM.Infrastructure.Entities.DTO
{
    public class Address
    {
        public int Number { get; set; }
        public string Label { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Address(int number, string label, string zipCode, string city, string country)
        {
            Number = number;
            Label = label;
            ZipCode = zipCode;
            City = city;
            Country = country;
        }
    }
}
