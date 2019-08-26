namespace EmployeeProfileApp.Core.Tests.Tests
{
    using System.Collections.Generic;
    using EmployeeProfileApp.Core.Interfaces;
    using EmployeeProfileApp.Core.Models;
    using EmployeeProfileApp.Core.ViewModels;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Main Menu View Model Tests
    /// </summary>
    public class MainMenuViewModelTests
    {
        /// <summary>
        /// Mains the menu view model tests find employee returns employee list and assigns it to employee details.
        /// </summary>
        [Test]
        public void MainMenuViewModelTests_FindEmployee_ReturnsEmployeeListAndAssignsItToEmployeeDetails()
        {
           var expectedEmployee = new List<EmployeeProfile>
           {
               new EmployeeProfile
               {
                   FirstName = "Matthew", LastName = string.Empty, Salary = 10000, DaysPerWeek = 5, HoursPerDay = 8, WeeksPerYear = 50
               }
           };

            Mock<IEmployeeProvider> mockEmployeeProvide = new Mock<IEmployeeProvider>();
            MainMenuViewModel addEmployeeViewModel = new MainMenuViewModel(mockEmployeeProvide.Object);
            mockEmployeeProvide.Setup(x => x.FindEmployee(It.IsAny<string>())).ReturnsAsync(expectedEmployee);

            addEmployeeViewModel.FindEmployeeCommand.Execute(It.IsAny<string>());
            
            Assert.AreEqual(expectedEmployee, addEmployeeViewModel.EmployeeDetails);
        }

        /// <summary>
        /// Mains the menu view model tests get random employee returns employee and assigns it to.
        /// </summary>
        [Test]
        public void MainMenuViewModelTests_GetRandomEmployee_ReturnsEmployeeAndAssignsItTo()
        {
            var expectedEmployee = new EmployeeProfile
            {
                FirstName = "Matthew", LastName = string.Empty, Salary = 10000, DaysPerWeek = 5, HoursPerDay = 8, WeeksPerYear = 50
            };

            var mockEmployeeProvide = new Mock<IEmployeeProvider>();
            var addEmployeeViewModel = new MainMenuViewModel(mockEmployeeProvide.Object);
            mockEmployeeProvide.Setup(x => x.GetRandomEmployee()).ReturnsAsync(expectedEmployee);

            addEmployeeViewModel.GetRandomEmployeeCommand.Execute();

            Assert.AreEqual(expectedEmployee, addEmployeeViewModel.SelectedEmployeeDetails);
        }
    }
}
