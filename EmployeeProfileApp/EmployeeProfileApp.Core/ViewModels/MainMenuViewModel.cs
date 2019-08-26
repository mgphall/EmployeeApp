namespace EmployeeProfileApp.Core.ViewModels
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EmployeeProfileApp.Core.Interfaces;
    using EmployeeProfileApp.Core.Models;
    using MvvmCross.Core.ViewModels;

    /// <summary>
    /// Main Menu View Model
    /// </summary>
    /// <seealso cref="EmployeeProfileApp.Core.ViewModels.ViewModelBase" />
    /// <seealso cref="IMainMenu" />
    public class MainMenuViewModel : ViewModelBase, IMainMenu
    { 
        /// <summary>
        /// The selected employee details
        /// </summary>
        private EmployeeProfile selectedEmployeeDetails;

        /// <summary>
        /// The employee details
        /// </summary>
        private IEnumerable<EmployeeProfile> employeeDetails;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenuViewModel"/> class.
        /// </summary>
        /// <param name="employeeProvider">The employee provider.</param>
        public MainMenuViewModel(IEmployeeProvider employeeProvider)
        {
            EmployeeProvider = employeeProvider;
        }

        /// <summary>
        /// Gets the add new employee command.
        /// </summary>
        public IMvxCommand AddNewEmployeeCommand => new MvxCommand(AddEmployeeView);

        /// <summary>
        /// Gets the find employee command.
        /// </summary>
        public IMvxCommand<string> FindEmployeeCommand => new MvxCommand<string>(async (pram) => await FindEmployee(pram));

        /// <summary>
        /// Gets the get random employee command.
        /// </summary>
        public IMvxCommand GetRandomEmployeeCommand => new MvxCommand(GetRandomEmployee);

        /// <summary>
        /// Gets or sets the selected employee details.
        /// </summary>
        public EmployeeProfile SelectedEmployeeDetails
        {
            get { return selectedEmployeeDetails; }
            set { SetProperty(ref selectedEmployeeDetails, value); }
        }

        /// <summary>
        /// Gets or sets the employee details.
        /// </summary>
        public IEnumerable<EmployeeProfile> EmployeeDetails
        {
            get { return employeeDetails; }
            set { SetProperty(ref employeeDetails, value); }
        }

        /// <summary>
        /// Gets or sets the employee provider.
        /// </summary>
        private IEmployeeProvider EmployeeProvider { get; }

        /// <summary>
        /// Gets the random employee.
        /// </summary>
        private async void GetRandomEmployee()
        {
            SelectedEmployeeDetails = await EmployeeProvider.GetRandomEmployee();
        }

        /// <summary>
        /// Finds the employee.
        /// </summary>
        /// <param name="search">The search.</param>
        /// <returns>a task</returns>
        private async Task FindEmployee(string search)
        {
            EmployeeDetails = await EmployeeProvider.FindEmployee(search);
        }

        /// <summary>
        /// Adds the employee view.
        /// </summary>
        private void AddEmployeeView()
        {
            ShowViewModel<AddEmployeeViewModel>();
        }
    }
}