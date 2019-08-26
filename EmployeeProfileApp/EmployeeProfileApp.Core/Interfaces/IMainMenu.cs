using EmployeeProfileApp.Core.Models;

namespace EmployeeProfileApp.Core.Interfaces
{
    /// <summary>
    /// Main Menu interface
    /// </summary>
    public interface IMainMenu
    {
        /// <summary>
        /// Gets or sets the selected employee details.
        /// </summary>
        EmployeeProfile SelectedEmployeeDetails { get; set; }
    }
}