namespace EmployeeProfileApp.Core.Provider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EmployeeProfileApp.Core.Interfaces;
    using EmployeeProfileApp.Core.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Employee Provider
    /// </summary>
    /// <seealso cref="EmployeeProfileApp.Core.Interfaces.IEmployeeProvider" />
    public class EmployeeProvider : IEmployeeProvider
    {
        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>success result</returns>
        public async Task<int> AddEmployee(EmployeeProfile employee)
        {
            using (var databaseContext = new DatabaseContext())
            {
                databaseContext.EmployeeProfile.Add(employee);
               return await databaseContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Finds the employee.
        /// </summary>
        /// <param name="search">The search.</param>
        /// <returns>
        /// results of search term
        /// </returns>
        public async Task<IList<EmployeeProfile>> FindEmployee(string search)
        {
            List<EmployeeProfile> result;
            
            using (var databaseContext = new DatabaseContext())
            {
                 result = await databaseContext.EmployeeProfile.Where(x => x.FirstName.Contains(search) || x.LastName.Contains(search))
                    .OrderBy(m => m.FirstName).ToListAsync();
            }

            return result;
        }

        /// <summary>
        /// Gets the random employee.
        /// </summary>
        /// <returns>
        /// Random Employee Profile
        /// </returns>
        public async Task<EmployeeProfile> GetRandomEmployee()
        {
            EmployeeProfile employee = null;

            using (var databaseContext = new DatabaseContext())
            {
                var count = databaseContext.EmployeeProfile.Count();
                var hasItems = count != 0;
                if (hasItems)
                {
                    var rand = new Random();
                    var toSkip = rand.Next(0, count);

                    employee = await databaseContext.EmployeeProfile.OrderBy(r => Guid.NewGuid()).Skip(toSkip).Take(1).SingleAsync();
                }

                return employee;
            }
        }
    }
}