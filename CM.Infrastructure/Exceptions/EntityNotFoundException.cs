using System.Runtime.Serialization;

namespace CM.Infrastructure.Exceptions;

public class EntityNotFoundException<TEntity> : Exception
{
    public EntityNotFoundException()
    {
    }

    public EntityNotFoundException(Guid id)
        : base($"Entity {typeof(TEntity)} of ID {id} not found")
    {
    }

    public EntityNotFoundException(string message)
        : base(message)
    {
    }

    public EntityNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    protected EntityNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}