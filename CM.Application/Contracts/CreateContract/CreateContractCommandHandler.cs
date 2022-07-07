using CM.Application.Contracts.Builders;
using CM.Application.Exceptions;
using CM.Infrastructure.Entities.Contracts;
using CM.Infrastructure.Entities.DTO;
using CM.Infrastructure.Repositories;
using MediatR;

namespace CM.Application.Contracts.CreateContract
{
    public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, Guid>
    {
        private readonly IContractRepository _contractRepository;

        public CreateContractCommandHandler(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public async Task<Guid> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            Contract contract;
            switch (request.ContractType)
            {
                case "CDD":
                {
                    var temporaryContractBuilder = TemporaryContractBuilder.GetInstance();
                    temporaryContractBuilder.Reset();
                    temporaryContractBuilder.SetGeneralInformations(request.DailyWorkTime, request.StartDate);
                    temporaryContractBuilder.SetType();
                    temporaryContractBuilder.SetTeleworkingAddress(new Address(request.Address.Number,
                        request.Address.Label, request.Address.ZipCode, request.Address.City, request.Address.Country));
                    temporaryContractBuilder.SetEndDate(request.EndDate);
                    temporaryContractBuilder.SetDailyRate(request.DailyRate);
                    contract = temporaryContractBuilder.GetContract();
                    break;
                }
                case "CDI":
                {
                    var permanentContractBuilder = PermanentContractBuilder.GetInstance();
                    permanentContractBuilder.Reset();
                    permanentContractBuilder.SetGeneralInformations(request.DailyWorkTime, request.StartDate);
                    permanentContractBuilder.SetType();
                    permanentContractBuilder.SetTeleworkingAddress(new Address(request.Address.Number,
                        request.Address.Label, request.Address.ZipCode, request.Address.City, request.Address.Country));
                    permanentContractBuilder.SetDailyRate(request.DailyRate);
                    contract = permanentContractBuilder.GetContract();
                    break;
                }
                case "INTERIM":
                {
                    var interimContractBuilder = InterimContractBuilder.GetInstance();
                    interimContractBuilder.Reset();
                    interimContractBuilder.SetGeneralInformations(request.DailyWorkTime, request.StartDate);
                    interimContractBuilder.SetType();
                    interimContractBuilder.SetTeleworkingAddress(new Address(request.Address.Number,
                        request.Address.Label, request.Address.ZipCode, request.Address.City, request.Address.Country));
                    interimContractBuilder.SetEndDate(request.EndDate);
                    interimContractBuilder.SetDailyRate(request.DailyRate);
                    contract = interimContractBuilder.GetContract();
                    break;
                }
                case "ALTERNANT":
                {
                    var apprenticeShipContractBuilder = ApprenticeshipContractBuilder.GetInstance();
                    apprenticeShipContractBuilder.Reset();
                    apprenticeShipContractBuilder.SetGeneralInformations(request.DailyWorkTime, request.StartDate);
                    apprenticeShipContractBuilder.SetType();
                    apprenticeShipContractBuilder.SetTeleworkingAddress(new Address(request.Address.Number,
                        request.Address.Label, request.Address.ZipCode, request.Address.City, request.Address.Country));
                    apprenticeShipContractBuilder.SetEndDate(request.EndDate);
                    apprenticeShipContractBuilder.SetDailyRate(request.DailyRate);
                    contract = apprenticeShipContractBuilder.GetContract();
                    break;
                }
                default:
                    throw new CMApplicationException("Unknown contract type : " + request.ContractType);
            }

            await _contractRepository.CreateContract(contract);

            return contract.Id;
        }
    }
}
