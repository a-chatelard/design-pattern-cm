using CM.Infrastructure.Context;
using CM.Infrastructure.Entities;
using CM.Infrastructure.Repositories.Specifications;
using Microsoft.EntityFrameworkCore;

namespace CM.Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task CreateUser(User user)
    {
        await CreateAsync(user);
    }

    public async Task<List<User>> GetUsersBySpecs(Specification<User> specs)
    {
        return await GetAllBySpecsAsync(specs);
    }

    public async Task<User?> GetUserBySpecs(Specification<User> specs)
    {
        return await GetSingleBySpecs(specs);
    }

    public async Task<User?> GetUserById(Guid userId)
    {
        return await GetAll().Include(u => u.Contracts).SingleOrDefaultAsync(u => u.Id == userId);
    }

    public async Task UpdateUser(User user)
    {
        await UpdateAsync(user);
    }

    public async Task DeleteUser(User user)
    {
        await DeleteAsync(user);
    }
}