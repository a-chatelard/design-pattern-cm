using System.Linq.Expressions;
using CM.Infrastructure.Entities.Base;

namespace CM.Infrastructure.Repositories.Specifications;

public class EntityIdSpecification<TEntity> : Specification<TEntity>
    where TEntity : Entity
{
    private readonly Guid _id;


    public EntityIdSpecification(Guid id)
    {
        _id = id;
    }

    public override Expression<Func<TEntity, bool>> ToExpression()
    {
        return e => _id == e.Id;
    }
}