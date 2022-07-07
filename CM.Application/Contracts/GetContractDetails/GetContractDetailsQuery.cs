using CM.API.Models.Results.Contracts;
using MediatR;

namespace CM.Application.Contracts.GetContractDetails
{
    public class GetContractDetailsQuery : IRequest<ContractDTO>
    {
        public Guid ContractId { get; }

        public GetContractDetailsQuery(Guid contractId)
        {
            ContractId = contractId;
        }
    }
}
