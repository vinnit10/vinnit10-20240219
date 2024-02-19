using EmployeeManagement.Contracts;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("v1")]
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorRepository _collaboratorRepository;
        public CollaboratorController(ICollaboratorRepository collaboratorRepository) 
        {
            _collaboratorRepository = collaboratorRepository;
        }

        [HttpPost("collaborator")]
        public async Task<IActionResult> createCollaboratorAsync(   
        [FromBody] Collaborator CreateCollaborator
        )
        {
            var collaborator = await _collaboratorRepository.CreateCollaborator(CreateCollaborator);
            if(collaborator == null)
                return NotFound("Unidade não encontrada no sistema como ativa!");

            return Ok("Colaborador cadastrado com sucesso!");
        }

        [HttpPut("collaborator/{Id:long}")]
        public async Task<IActionResult> UpdateCollaboratorAsync(
        [FromRoute] long Id,
        [FromBody] UpdateCollaboratorViewModel updateCollaborator
        )
        {
            var collaborator = await _collaboratorRepository.UpdateCollaborator(updateCollaborator, Id);
            if (collaborator == null)
                return NotFound("Collaborator ou Unidade não encontrada no sitema!");

            return Ok(collaborator);
        }

        [HttpDelete("collaborator/{Id:long}")]
        public async Task<IActionResult> DeleteCollaboratorAsync(
        [FromRoute] long Id
        )
        {
            var collaborator = await _collaboratorRepository.DeleteCollaborator(Id);
            if (collaborator == null)
                return NotFound("Collaborator não encontrado no sistema!");

            return Ok("Colaborador Removido com sucesso!");
        }

        [HttpGet("collaborator")]
        public async Task<IActionResult> GetAllCollaboratorsAsync()
        {
            var collaborators = await _collaboratorRepository.GetAllCollaborators();

            return Ok(collaborators);
        }
    }
}
