using EmployeeManagement.Contracts;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly ManagementDbContext _context;
        public CollaboratorRepository(ManagementDbContext context) 
        {
            _context = context;
        }
        
        public async Task<Collaborator?> CreateCollaborator(Collaborator collaborator)
        {
            var unit = _context.Units.FirstOrDefault(x => x.Code == collaborator.UnitCode && x.Enabled);
            if(unit == null)
                return null;

            await _context.Collaborators.AddAsync(collaborator);
            await _context.SaveChangesAsync();
                
            return collaborator;
        }

        public async Task<Collaborator?> UpdateCollaborator(UpdateCollaboratorViewModel updateCollaborator, long id)
        {
            var collaborator = await _context.Collaborators.FirstOrDefaultAsync(x => x.Id == id);
            if(collaborator == null)
                return null;

            var unit = await _context.Units.ToListAsync();
            var unitCollaborator = unit.FirstOrDefault(x => x.Id == updateCollaborator.UnitCode);

            if (unitCollaborator == null) 
                return null;

            if (!string.IsNullOrWhiteSpace(updateCollaborator.Name))
                collaborator.Name = updateCollaborator.Name;

            collaborator.UnitCode = updateCollaborator.UnitCode;

            await _context.SaveChangesAsync();

            return collaborator;
        }

        public async Task<long?> DeleteCollaborator(long id)
        {
            var collaborator = await _context.Collaborators.FirstOrDefaultAsync(x => x.Id == id);
            if (collaborator == null)
                return null;

             _context.Collaborators.Remove(collaborator);
            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<List<Collaborator>> GetAllCollaborators()
        {
            var collaborators = await _context.Collaborators.ToListAsync();
            return collaborators;
        }

    }
}
