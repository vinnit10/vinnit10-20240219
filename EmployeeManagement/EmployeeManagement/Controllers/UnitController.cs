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
    public class UnitController : ControllerBase
    {
        private readonly IUnitRepository _unitRepository;
        public UnitController(IUnitRepository unitRepository) 
        {
            _unitRepository = unitRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUnit([FromBody] Unit unit)
        {
            await _unitRepository.CreateUnitAsync(unit);
            return Ok("Unidade cadastrada com sucesso!");
        }

        [HttpPut("unit/{id:long}")]
        public async Task<IActionResult> UpdateUnitAsync(
        [FromRoute]long id,
        [FromBody] UpdateUnitViewModel updateUnit
        )
        {
            var unit = await _unitRepository.UpdateUnitAsync(updateUnit, id);

            if (unit == null)
                return NotFound("Unidade não encontrada!");

            return Ok("Unidade atualizada com sucesso com sucesso!");
        }

        [HttpGet("unit")]
        public async Task<IActionResult> GetAllUnitsAsync()
        {
            var units = await _unitRepository.GetAllUnits();
            return Ok(units);
        }


    }
}
