using CM.API.Models.Requests;
using CM.Application.Shared;
using MediatR;

namespace CM.Application.Contracts.CreateContract
{
    public class CreateContractCommand : IRequest<Guid>
    {
        public string ContractType { get; }

        public TimeSpan DailyWorkTime { get; }
        public DateTime StartDate { get; }
        public DateTime? EndDate { get; }
        public double DailyRate { get; }
        public AddressCommand Address { get; }

        public CreateContractCommand(string contractType, ContractRequestDTO dto)
        {
            ContractType = contractType;
            DailyWorkTime = dto.DailyWorkTime;
            StartDate = dto.StartDate;
            EndDate = dto.EndDate;
            DailyRate = dto.DailyRate;
            Address = new AddressCommand(dto.Address);
        }
    }
}
