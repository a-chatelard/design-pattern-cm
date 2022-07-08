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

    /// <summary>
    /// Récupération de tous les contrats.
    /// </summary>
    /// <param name="filter">
    /// Filtres :
    /// - ContratType : PERMANENT / TEMPORARY / APPRENTICESHIP / INTERIM
    /// - DailyRate : Nombre à virgule
    /// - DailyRateComparator : &gt; / &lt;
    /// </param>
    /// <returns>La liste des contrats (correspondante au filtre si indiqué)</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContractDTO>>> GetAllContracts([FromQuery] ContractFilterRequest? filter)
    {
        var query = new GetAllContractsQuery(filter);

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    /// <summary>
    /// Récupération d'un contrat via son identifiant.
    /// </summary>
    /// <param name="contractId">L'identifiant du contrat.</param>
    /// <returns>Le contrat correspondant.</returns>
    [HttpGet("{contractId:guid}")]
    public async Task<ActionResult<ContractDTO>> GetContractById(Guid contractId)
    {
        var query = new GetContractDetailsQuery(contractId);

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    /// <summary>
    /// Création d'un contrat.
    /// </summary>
    /// <param name="contractType">CDD / CDI / ALTERNANT / INTERIM</param>
    /// <param name="contractDTO">
    /// - DailyWorkTime : Format nécessaire : "XX:XX:XX" (compris entre 00:00:01 et 23:59:59).
    /// - StartDate : Format date classique.
    /// - EndDate : Format date classique.
    /// - DailyRate : Format nombre.
    /// <br /> Address :
    /// - Number : Nombre entier.
    /// - Label : Chaine de caractère.
    /// - ZipCode : Chaine de caractère.
    /// - City : Chaine de caractère.
    /// - Country : Chaine de caractère.
    /// </param>
    /// <returns>The ID of the created contract.</returns>
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateContract([FromQuery] string contractType, [FromBody] ContractRequestDTO contractDTO)
    {
        var command = new CreateContractCommand(contractType, contractDTO);

        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(CreateContract), result);
    }

    /// <summary>
    /// Suppression d'un contrat via son identifiant.
    /// </summary>
    /// <param name="contractId">Identifiant du contrat.</param>
    [HttpDelete("{contractId:guid}")]
    public async Task<IActionResult> DeleteContract(Guid contractId)
    {
        var command = new DeleteContractCommand(contractId);

        await _mediator.Send(command);

        return Ok();
    }
    
    /// <summary>
    /// Modification de l'état d'un contrat.
    /// </summary>
    /// <param name="contractId">Identifiant du contrat à modifier.</param>
    /// <param name="state">Format de l'état : chaine de caractère : close / deny / send / sign</param>
    /// <returns>Le contrat modifié.</returns>
    [HttpPatch("{contractId:guid}")]
    public async Task<ActionResult<ContractDTO>> UpdateContractState(Guid contractId, [FromBody] string state)
    {
        var command = new UpdateContractStateCommand(contractId, state);

        var result = await _mediator.Send(command);

        return Ok(result);
    }
}