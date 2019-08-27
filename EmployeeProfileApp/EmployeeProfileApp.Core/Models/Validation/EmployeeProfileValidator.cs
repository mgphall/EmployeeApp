namespace EmployeeProfileApp.Core.Models.Validation
{
    using FluentValidation;

    /// <summary>
    /// Validation rules for the Employee Profile model
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{EmployeeProfileApp.Core.Models.EmployeeProfile}" />
    public class EmployeeProfileValidator : AbstractValidator<EmployeeProfile>
    {
        /// <summary>
        /// The letters and spaces
        /// </summary>
        private readonly string lettersAndSpaces = @"^[a-zA-Z]+(\s[a-zA-Z]+)?$";

        /// <summary>
        /// The scale
        /// </summary>
        private readonly int scale =2;

        /// <summary>
        /// The precision
        /// </summary>
        private readonly int precision = 12;

        /// <summary>
        /// The maximum hours
        /// </summary>
        private readonly int maxHours = 24;

        /// <summary>
        /// The maximum days
        /// </summary>
        private readonly int maxDays = 7;

        /// <summary>
        /// The maximum weeks
        /// </summary>
        private readonly int maxWeeks = 52;

        /// <summary>
        /// The maximum length
        /// </summary>
        private readonly int maxLength = 35;

        /// <summary>
        /// The minimum length
        /// </summary>
        private readonly int minLength = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeProfileValidator"/> class.
        /// </summary>
        public EmployeeProfileValidator()
        {
            RuleFor(x => x.FirstName).Length(minLength, maxLength).NotEmpty().Matches(lettersAndSpaces);
            RuleFor(x => x.LastName).Length(minLength, maxLength).NotEmpty().Matches(lettersAndSpaces);
            RuleFor(x => x.Salary).ScalePrecision(scale, precision).GreaterThan(0);
            RuleFor(x => x.HoursPerDay).InclusiveBetween(1, maxHours);
            RuleFor(x => x.DaysPerWeek).InclusiveBetween(1, maxDays);
            RuleFor(x => x.WeeksPerYear).InclusiveBetween(1, maxWeeks);
        } 
    }
}