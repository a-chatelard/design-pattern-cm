using CM.Application.Exceptions;
using CM.Infrastructure.Entities.Contracts;
using CM.Infrastructure.Entities.DTO;

namespace CM.Application.Contracts.Builders
{
    public sealed class TemporaryContractBuilder : IContractBuilder
    {
        private static TemporaryContractBuilder? _instance;

        public static TemporaryContractBuilder GetInstance()
        {
            return _instance ??= new TemporaryContractBuilder();
        }

        private Contract _contract = new();

        public void Reset()
        {
            _contract = new Contract();
        }

        public void SetGeneralInformations(TimeSpan weeklyWorkTime, DateTime startDate)
        {
            _contract.Title = "CONTRAT DURÉE DÉTERMINÉE";
            _contract.Description = "Suspendisse luctus id augue nec tempor." +
                                    " Pellentesque quis ligula sagittis, dictum eros vitae, venenatis quam. " +
                                    "Aenean eu commodo mi, et lacinia dolor.Nulla at neque ipsum. " +
                                    "Donec sed neque sit amet enim hendrerit volutpat.";
            _contract.StartDate = startDate;
            _contract.DailyWorkTime = weeklyWorkTime;
        }

        public void SetType()
        {
            _contract.Type = ContractType.TEMPORARY;
        }

        public void SetTeleworkingAddress(Address address)
        {
            _contract.TeleworkingAddress = address;
        }

        public void SetEndDate(DateTime? endDate)
        {
            if (!endDate.HasValue)
            {
                throw new CMApplicationException("Cannot create temporary contract without end date.");
            }
            _contract.EndDate = endDate;
        }

        public void SetDailyRate(double dailyRate)
        {
            _contract.DailyRate = dailyRate * 1.2;
        }

        public Contract GetContract()
        {
            return _contract;
        }
    }
}
