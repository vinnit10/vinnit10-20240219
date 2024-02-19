using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Contracts
{
    public interface IUnitRepository
    {
        public Task<Unit> CreateUnitAsync(Unit unit);

        public Task<Unit?> UpdateUnitAsync(UpdateUnitViewModel updateUnit, long id);

        public Task<List<UnitsViewModel>> GetAllUnits();
    }
}
