namespace EmployeeProfileApp.Core.Interfaces
{
    /// <summary>
    /// Employee Profile 
    /// </summary>
    public interface IEmployeeProfile
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        string FirstName { get; set; }
        
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        string LastName { get; set; }
        
        /// <summary>
        /// Gets or sets the salary.
        /// </summary>
        decimal Salary { get; set; }

        /// <summary>
        /// Gets or sets the hours per day.
        /// </summary>
        int HoursPerDay { get; set; }
        
        /// <summary>
        /// Gets or sets the days per week.
        /// </summary>
        int DaysPerWeek { get; set; }
        
        /// <summary>
        /// Gets or sets the weeks per year.
        /// </summary>
        int WeeksPerYear { get; set; }
    }
}