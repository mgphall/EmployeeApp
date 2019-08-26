using EmployeeProfileApp.Core.Models;

namespace EmployeeProfileApp.Core.Interfaces
{
    /// <summary>
    /// Add Employee View Model
    /// </summary>
    public interface IAddEmployeeViewModel
    {
        /// <summary>
        /// Gets or sets the employee details.
        /// </summary>
        IEmployeeProfile EmployeeDetails { get; set; }
    }
}