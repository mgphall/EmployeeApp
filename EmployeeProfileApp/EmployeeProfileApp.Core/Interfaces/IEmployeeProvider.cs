namespace EmployeeProfileApp.Core.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EmployeeProfileApp.Core.Models;

    /// <summary>
    /// EmployeeProvider interfaces
    /// </summary>
    public interface IEmployeeProvider
    {
        /// <summary>
        /// Gets the random employee.
        /// </summary>
        /// <returns>Employee Profile</returns>
        Task<EmployeeProfile> GetRandomEmployee();

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="employeeProfile">The employee profile.</param>
        /// <returns>result of task</returns>
        Task<int> AddEmployee(EmployeeProfile employeeProfile);

        /// <summary>
        /// Finds the employee.
        /// </summary>
        /// <param name="search">The search.</param>
        /// <returns>results of search term</returns>
        Task<IList<EmployeeProfile>> FindEmployee(string search);
    }
}
