using CM.API.Models.Requests;
using CM.API.Models.Results.Contracts;
using CM.Application.Contracts.CreateContract;
using CM.Application.Contracts.DeleteContract;
using CM.Application.Contracts.GetAllContracts;
using CM.Application.Contracts.GetContractDetails;
using CM.Infrastructure.Entities.ContractStates;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CM.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ContractController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContractController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContractDTO>>> GetAllContracts([FromQuery] ContractFilterRequest? filter)
    {
        var query = new GetAllContractsQuery(filter);

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{contractId:guid}")]
    public async Task<ActionResult<ContractDTO>> GetContractById(Guid contractId)
    {
        var query = new GetContractDetailsQuery(contractId);

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateContract([FromQuery] string contractType, [FromBody] ContractRequestDTO contractDTO)
    {
        var command = new CreateContractCommand(contractType, contractDTO);

        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(CreateContract), result);
    }

    [HttpDelete("{contractId:guid}")]
    public async Task<IActionResult> DeleteContract(Guid contractId)
    {
        var command = new DeleteContractCommand(contractId);

        await _mediator.Send(command);

        return Ok();
    }

    [HttpPatch("{contractId:guid}")]
    public async Task<ActionResult<ContractDTO>> UpdateContractState(Guid contractId, [FromBody] string state)
    {
        var command = new UpdateContractStateCommand(contractId, state);

        var result = await _mediator.Send(command);

        return Ok(result);
    }
}