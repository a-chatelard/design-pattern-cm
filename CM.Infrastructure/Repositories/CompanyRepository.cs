using CM.Infrastructure.Context;
using CM.Infrastructure.Entities.Companies;
using CM.Infrastructure.Repositories.Specifications;
using Microsoft.EntityFrameworkCore;

namespace CM.Infrastructure.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task CreateCompany(Company company)
        {
            await CreateAsync(company);
        }

        public async Task<List<Company>> GetCompaniesBySpecs(Specification<Company> specs)
        {
            return await GetAllBySpecsAsync(specs);
        }

        public async Task<Company?> GetCompanyBySpecs(Specification<Company> specs)
        {
            return await GetSingleBySpecs(specs);
        }

        public async Task<Company?> GetCompanyById(Guid companyId)
        {
            return await GetAll().Include(c => c.Contracts).SingleOrDefaultAsync(c => c.Id == companyId);
        }

        public async Task UpdateCompany(Company company)
        {
            await UpdateAsync(company);
        }

        public async Task DeleteCompany(Company company)
        {
            await DeleteAsync(company);
        }
    }
}
