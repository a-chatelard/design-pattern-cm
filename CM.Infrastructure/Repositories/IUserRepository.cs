using CM.Infrastructure.Entities;
using CM.Infrastructure.Repositories.Specifications;

namespace CM.Infrastructure.Repositories;

public interface IUserRepository
{
    Task CreateUser(User user);
    
    Task<List<User>> GetUsersBySpecs(Specification<User> specs);
    
    Task<User?> GetUserBySpecs(Specification<User> specs);
    
    Task<User?> GetUserById(Guid userId);
    
    Task UpdateUser(User user);
    
    Task DeleteUser(User user);
}