using CM.Application.Exceptions;
using CM.Infrastructure.Entities.Contracts;
using CM.Infrastructure.Entities.DTO;

namespace CM.Application.Contracts.Builders
{
    public class PermanentContractBuilder : IContractBuilder
    {
        private static PermanentContractBuilder? _instance;

        public static PermanentContractBuilder GetInstance()
        {
            return _instance ??= new PermanentContractBuilder();
        }

        private Contract _contract = new();

        public void Reset()
        {
            _contract = new Contract();
        }

        public void SetGeneralInformations(TimeSpan weeklyWorkTime, DateTime startDate)
        {
            _contract.Title = "CONTRAT À DURÉE INDÉTERMINÉE";
            _contract.Description = "Ut fermentum et nulla a sollicitudin." +
                                    " Sed et tincidunt tellus, eu cursus purus. " +
                                    "In tellus ante, mollis non consectetur eget, dictum ut ligula. " +
                                    "Maecenas tincidunt urna lorem, a porttitor lacus fermentum at. " +
                                    "Vestibulum quis eros dapibus tellus molestie rutrum a sed mi.";
            _contract.StartDate = startDate;
            _contract.DailyWorkTime = weeklyWorkTime;
        }

        public void SetType()
        {
            _contract.Type = ContractType.PERMANENT;
        }

        public void SetTeleworkingAddress(Address address)
        {
            _contract.TeleworkingAddress = address;
        }

        public void SetEndDate(DateTime? endDate)
        {
            throw new CMApplicationException("Cannot set the end date of a permanent contract.");
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
