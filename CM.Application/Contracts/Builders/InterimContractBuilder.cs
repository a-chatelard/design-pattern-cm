using CM.Infrastructure.Entities.Contracts;
using CM.Infrastructure.Entities.DTO;

namespace CM.Application.Contracts.Builders
{
    public class InterimContractBuilder : IContractBuilder
    {
        private static InterimContractBuilder? _instance;

        public static InterimContractBuilder GetInstance()
        {
            return _instance ??= new InterimContractBuilder();
        }

        private Contract _contract = new();

        public void Reset()
        {
            _contract = new Contract();
        }

        public void SetGeneralInformations(TimeSpan weeklyWorkTime, DateTime startDate)
        {
            _contract.Title = "CONTRAT INTÉRIMAIRE";
            _contract.Description =
                "Quisque iaculis ut ipsum et vulputate. Fusce varius egestas arcu, ut maximus lacus." +
                "Aliquam condimentum magna eget convallis viverra. Fusce imperdiet mattis dui, eget eleifend diam ornare quis." +
                "Sed placerat leo ut erat luctus ultrices. Curabitur lobortis mauris vel mi sagittis rutrum.";

            _contract.StartDate = startDate;
            _contract.DailyWorkTime = weeklyWorkTime;
        }

        public void SetType()
        {
            _contract.Type = ContractType.INTERIM;
        }

        public void SetTeleworkingAddress(Address address)
        {
            _contract.TeleworkingAddress = address;
        }

        public void SetEndDate(DateTime? endDate)
        {
            _contract.EndDate = endDate;
        }

        public void SetDailyRate(double dailyRate)
        {
            _contract.DailyRate = dailyRate;
        }

        public Contract GetContract()
        {
            return _contract;
        }
    }
}
