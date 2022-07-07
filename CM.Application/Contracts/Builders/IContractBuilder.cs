using CM.Infrastructure.Entities.Contracts;
using CM.Infrastructure.Entities.DTO;

namespace CM.Application.Contracts.Builders
{
    public interface IContractBuilder
    {
        void Reset();

        void SetGeneralInformations(TimeSpan weeklyWorkTime, DateTime startDate);

        void SetType();

        void SetTeleworkingAddress(Address address);

        void SetEndDate(DateTime? endDate);

        void SetDailyRate(double dailyRate);

        Contract GetContract();
    }
}

// PASSER SUR UNE FACTORY PLUS SIMPLE