using EmployeeManagement.Contracts;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly ManagementDbContext _context;

        public UnitRepository(ManagementDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> CreateUnitAsync(Unit unit)
        {
            _context.Units.Add(unit);
            await _context.SaveChangesAsync();

            return unit;
        }

        public async Task<Unit?> UpdateUnitAsync(UpdateUnitViewModel updateUnit, long id)
        {
            var unit = _context.Units.Where(x => x.Id == id).FirstOrDefault();
            if (unit == null)
                return null;

            unit.Enabled = updateUnit.Enabled;
            _context.Units.Update(unit);
            await _context.SaveChangesAsync();

            return unit;
        }

        public async Task<List<UnitsViewModel>> GetAllUnits()
        {
            var units = await _context.Units.ToListAsync();
            var collaborators = await _context.Collaborators.ToListAsync();
            var unitsViewModel = new List<UnitsViewModel>();

            foreach (var unit in units)
            {
                var unitCollaborators = collaborators.Where(x => x.UnitCode == unit.Code).ToList();

                var unitViewModel = new UnitsViewModel()
                {
                    Id = unit.Id,
                    Code = unit.Code,
                    Name = unit.Name,
                    Enabled = unit.Enabled,
                    Collaborators = unitCollaborators,
                };

                unitsViewModel.Add(unitViewModel);
            }

            return unitsViewModel;
        }

    }
}
