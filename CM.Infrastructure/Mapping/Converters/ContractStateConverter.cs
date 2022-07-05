using CM.Infrastructure.Entities.ContractStates;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CM.Infrastructure.Mapping.Converters;

public class ContractStateConverter : ValueConverter<ContractState, string>
{
    public ContractStateConverter() : 
        base(state => state.ToString(), stringState => ContractState.FromString(stringState))
    {
    }
}