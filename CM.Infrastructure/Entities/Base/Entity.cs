namespace CM.Infrastructure.Entities.Base;

public class Entity : IEntity<Guid>
{
    public Guid Id { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime DeletedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}