using System;

namespace EmployeeProfileApp.Core.ViewModels
{
    using System.Threading.Tasks;
    using EmployeeProfileApp.Core.Interfaces;
    using EmployeeProfileApp.Core.Models;
    using EmployeeProfileApp.Core.Models.Validation;
    using MvvmCross.Core.ViewModels;

    /// <summary>
    /// Add Employee View Model
    /// </summary>
    /// <seealso cref="EmployeeProfileApp.Core.ViewModels.ViewModelBase" />
    /// <seealso cref="IAddEmployeeViewModel" />
    public class AddEmployeeViewModel : ViewModelBase, IAddEmployeeViewModel
    {
        /// <summary>
        /// The employee details
        /// </summary>
        private IEmployeeProfile employeeDetails = new EmployeeProfile();

        /// <summary>
        /// The save button enabled
        /// </summary>
        private bool saveButtonEnabled = true;

        /// <summary>
        /// The message
        /// </summary>
        private string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddEmployeeViewModel"/> class.
        /// </summary>
        /// <param name="employeeProvider">The employee provider.</param>
        public AddEmployeeViewModel(IEmployeeProvider employeeProvider)
        {
            EmployeeProvider = employeeProvider;
        }

        /// <summary>
        /// Gets the save command.
        /// </summary>
        public IMvxCommand SaveCommand => new MvxCommand<EmployeeProfile>(async (param) => await SaveEmployee(param));

        /// <summary>
        /// Gets the back command.
        /// </summary>
        public IMvxCommand BackCommand => new MvxCommand(() => ShowViewModel<MainMenuViewModel>());

        /// <summary>
        /// Gets the employee provider.
        /// </summary>
        public IEmployeeProvider EmployeeProvider { get; }

        /// <summary>
        /// Gets or sets the employee details.
        /// </summary>
        public IEmployeeProfile EmployeeDetails
        {
            get { return employeeDetails; }
            set { SetProperty(ref employeeDetails, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [save button enabled].
        /// </summary>
        public bool SaveButtonEnabled
        {
            get { return saveButtonEnabled; }
            set { SetProperty(ref saveButtonEnabled, value); }
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        /// <summary>
        /// Saves the employee.
        /// </summary>
        /// <param name="profile">The profile.</param>
        /// <returns>a Task</returns>
        private async Task SaveEmployee(IEmployeeProfile profile)
        {
            SaveButtonEnabled = false;

            var tempPerson = new EmployeeProfile
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Salary = profile.Salary,
                HoursPerDay = profile.HoursPerDay,
                DaysPerWeek = profile.DaysPerWeek,
                WeeksPerYear = profile.WeeksPerYear
            };

            var validator = new EmployeeProfileValidator();
            var results = validator.Validate(tempPerson);

            if (results.IsValid)
            {
                var saveSuccess = await EmployeeProvider.AddEmployee(tempPerson);

                Message = saveSuccess == 1 ? "Employee Details saved" : "Unable able to save Employee Details";
            }
            else
            {
                foreach (var error in results.Errors)
                {
                    Message = error.ErrorMessage;
                }
            }

            SaveButtonEnabled = true;
            Message = string.Empty;
        }
    }
}