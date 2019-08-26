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
        private string lettersAndSpaces = @"^[a-zA-Z]+(\s[a-zA-Z]+)?$";

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeProfileValidator"/> class.
        /// </summary>
        public EmployeeProfileValidator()
        {
            RuleFor(x => x.FirstName).Length(1, 20).NotEmpty().Matches(lettersAndSpaces).WithMessage("Please specify a valid first name");
            RuleFor(x => x.LastName).Length(1, 20).NotEmpty().Matches(lettersAndSpaces).WithMessage("Please specify a valid Last Name");
            RuleFor(x => x.Salary).ScalePrecision(2,20).GreaterThan(0).WithMessage("Please specify a valid salary");
            RuleFor(x => x.HoursPerDay).InclusiveBetween(1, 24).WithMessage("Please specify a valid hours per day");
            RuleFor(x => x.DaysPerWeek).InclusiveBetween(1, 7).WithMessage("Please specify a valid days per week");
            RuleFor(x => x.WeeksPerYear).InclusiveBetween(1, 52).WithMessage("Please specify a valid Week per year");
        } 
    }
}