using CM.Infrastructure.Entities.Contracts;

namespace CM.Application.Contracts.Builders
{
    public interface IContractBuilder
    {
        void setGeneralInformations(string title, string description, TimeSpan weeklyWorkTime, DateTime startDate);

        void setType(ContractType type);

        void setTeleworkingAddress();
    }
}

// PASSER SUR UNE FACTORY PLUS SIMPLE