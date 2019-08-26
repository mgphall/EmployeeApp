using EmployeeProfileApp.Core.Interfaces;

namespace EmployeeProfileApp.Core.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Employee Profile data model
    /// </summary>
    /// <seealso cref="IEmployeeProfile" />
    [Table("EmployeeProfile")]
    public class EmployeeProfile : IEmployeeProfile
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Gets or sets the salary.
        /// </summary>
        public decimal Salary { get; set; }

        /// <summary>
        /// Gets or sets the hours per day.
        /// </summary>
        /// <value>
        /// The hours per day.
        /// </value>
        public int HoursPerDay { get; set; }
       
        /// <summary>
        /// Gets or sets the days per week.
        /// </summary>
        public int DaysPerWeek { get; set; }
        
        /// <summary>
        /// Gets or sets the weeks per year.
        /// </summary>
        public int WeeksPerYear { get; set; }
    }
}
