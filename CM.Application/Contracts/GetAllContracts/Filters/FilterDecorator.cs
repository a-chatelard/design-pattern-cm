using CM.Infrastructure.Entities.Contracts;
using CM.Infrastructure.Repositories.Specifications;

namespace CM.Application.Contracts.GetAllContracts.Filters;

public class FilterDecorator : FilterComponent
{
    protected FilterComponent Component;

    public FilterDecorator(FilterComponent component)
    {
        Component = component;
    }

    public override Specification<Contract> ApplySpecs()
    {
        return Component.ApplySpecs();
    }
}