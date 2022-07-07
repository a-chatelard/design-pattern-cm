using System.Linq.Expressions;

namespace CM.Infrastructure.Repositories.Specifications;

public class IdentitySpecification<T> : Specification<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        return x => true;
    }
}