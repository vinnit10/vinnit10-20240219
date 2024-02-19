using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Contracts
{
    public interface ICollaboratorRepository
    {
        public Task<Collaborator?> CreateCollaborator(Collaborator collaborator);
        public Task<Collaborator?> UpdateCollaborator(UpdateCollaboratorViewModel updateCollaborator, long id);
        public Task<long?> DeleteCollaborator(long id);
        public Task<List<Collaborator>> GetAllCollaborators();



    }
}
