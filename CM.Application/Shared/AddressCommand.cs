using CM.API.Models.Requests;

namespace CM.Application.Shared
{
    public class AddressCommand
    {
        public int Number { get; }
        public string Label { get; }
        public string ZipCode { get; }
        public string City { get; }
        public string Country { get; }

        public AddressCommand(AddressRequestDTO addressDTO)
        {
            Number = addressDTO.Number;
            Label = addressDTO.Label;
            ZipCode = addressDTO.ZipCode;
            City = addressDTO.City;
            Country = addressDTO.Country;
        }
    }
}
