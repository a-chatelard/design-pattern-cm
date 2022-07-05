using CM.Infrastructure.Entities.Companies;
using CM.Infrastructure.Repositories.Specifications;

namespace CM.Infrastructure.Repositories
{
    public interface ICompanyRepository
    {
        Task CreateCompany(Company company);

        Task<List<Company>> GetCompaniesBySpecs(Specification<Company> specs);

        Task<Company?> GetCompanyBySpecs(Specification<Company> specs);

        Task<Company?> GetCompanyById(Guid companyId);

        Task UpdateCompany(Company company);

        Task DeleteCompany(Company company);
    }
}
