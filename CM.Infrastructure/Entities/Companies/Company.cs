using CM.Infrastructure.Entities.Base;
using CM.Infrastructure.Entities.Contracts;
using CM.Infrastructure.Entities.DTO;

namespace CM.Infrastructure.Entities.Companies
{
    public class Company : Entity
    {
        public string Label { get; set; }

        public CompanyType Type { get; set; }

        public Address Address { get; set; }

        public List<Contract> Contracts { get; set; }
    }
}
