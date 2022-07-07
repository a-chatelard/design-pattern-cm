using CM.Infrastructure.Entities.Contracts;
using CM.Infrastructure.Entities.DTO;

namespace CM.Application.Contracts.Builders
{
    public class ApprenticeshipContractBuilder : IContractBuilder
    {
        private static ApprenticeshipContractBuilder? _instance;

        public static ApprenticeshipContractBuilder GetInstance()
        {
            return _instance ??= new ApprenticeshipContractBuilder();
        }

        private Contract _contract = new();

        public void Reset()
        {
            _contract = new Contract();
        }

        public void SetGeneralInformations(TimeSpan weeklyWorkTime, DateTime startDate)
        {
            _contract.Title = "CONTRAT D'APPRENTISSAGE";
            _contract.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                                   "Praesent id lacus eget mi ultricies aliquam eu et lacus. Aliquam felis mauris, semper nec consequat ac, pharetra sed quam." +
                                   " Nunc molestie quis risus quis maximus. Sed auctor felis congue, finibus tellus quis, semper nisl." +
                                   " Vestibulum ultrices ligula a faucibus mollis. " +
                                   "Quisque semper leo at turpis viverra mollis. Interdum et malesuada fames ac ante ipsum primis in faucibus." +
                                   " Integer rutrum ac turpis nec mattis.";

            _contract.DailyWorkTime = weeklyWorkTime;
            _contract.StartDate = startDate;
        }

        public void SetType()
        {
            _contract.Type = ContractType.APPRENTICESHIP;
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
            _contract.DailyRate = dailyRate / 2;
        }

        public Contract GetContract()
        {
            return _contract;
        }
    }
}
