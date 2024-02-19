using EmployeeManagement.Models;

namespace EmployeeManagement.ViewModels
{
    public class UnitsViewModel
    {
        public long Id { get; set; }
        public int Code { get; set; }
        public string? Name { get; set; }
        public bool Enabled { get; set; }
        public List<Collaborator>? Collaborators { get; set; }
    }
}
