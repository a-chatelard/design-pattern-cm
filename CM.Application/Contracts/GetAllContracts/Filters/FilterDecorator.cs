using CM.Infrastructure.Entities.Contracts;
using CM.Infrastructure.Repositories.Specifications;

namespace CM.Application.Contracts.GetAllContracts.Filters;

public class FilterDecorator : FilterComponent
{
    protected FilterComponent Component;

    public FilterDecorator()
    {
        
    }

    public FilterDecorator(FilterComponent component)
    {
        Component = component;
    }

    public void SetComponent(FilterComponent component)
    {
        Component = component;
    }

    public override Specification<Contract> ApplySpecs()
    {
        return Component.ApplySpecs();
    }
}