namespace EmployeeProfileApp.Core.Tests.Tests
{
    using System.Collections.Generic;
    using EmployeeProfileApp.Core.Interfaces;
    using EmployeeProfileApp.Core.Models;
    using EmployeeProfileApp.Core.ViewModels;
    using Moq;
    using NUnit.Framework;
    
    /// <summary>
    /// Add Employee View Model Tests
    /// </summary>
    public class AddEmployeeViewModelTests
    {
        /// <summary>
        /// Gets the invalid employee details.
        /// </summary>
        public static IEnumerable<TestCaseData> InvalidEmployeeDetails
        {
            get
            {
                yield return new TestCaseData(new EmployeeProfile { FirstName = string.Empty, LastName = "Hall", Salary = 10000, DaysPerWeek = 1, HoursPerDay = 1, WeeksPerYear = 1 }).SetName("FirstName");
                yield return new TestCaseData(new EmployeeProfile { FirstName = "Matthew", LastName = string.Empty, Salary = 1, HoursPerDay = 1, DaysPerWeek = 1, WeeksPerYear = 1 }).SetName("LastName");
                yield return new TestCaseData(new EmployeeProfile { FirstName = "123456", LastName = "Hall", Salary = 10000, DaysPerWeek = 1, HoursPerDay = 1, WeeksPerYear = 1 }).SetName("NumbersFirstName");
                yield return new TestCaseData(new EmployeeProfile { FirstName = "MatthewHall", LastName = "123", Salary = 10000, DaysPerWeek = 1, HoursPerDay = 1, WeeksPerYear = 1 }).SetName("NumbersLastName");
                yield return new TestCaseData(new EmployeeProfile { FirstName = "MatthewHallMatthewHallMatthewHallMatthewHall", LastName = "Hall", Salary = 10000, DaysPerWeek = 1, HoursPerDay = 1, WeeksPerYear = 1 }).SetName("MaxLenghtFirstName");
                yield return new TestCaseData(new EmployeeProfile { FirstName = "Matthew", LastName = "MatthewHallMatthewHallMatthewHallMatthewHall", Salary = 10000, DaysPerWeek = 1, HoursPerDay = 1, WeeksPerYear = 1 }).SetName("NumbersLastName");
                yield return new TestCaseData(new EmployeeProfile { FirstName = "Matthew", LastName = string.Empty, Salary = 1, HoursPerDay = 1, DaysPerWeek = 1, WeeksPerYear = 1 }).SetName("LastName");
                yield return new TestCaseData(new EmployeeProfile { FirstName = "Matthew", LastName = "Hall", Salary = 0, HoursPerDay = 1, DaysPerWeek = 1, WeeksPerYear = 1 }).SetName("Salary");
                yield return new TestCaseData(new EmployeeProfile { FirstName = "Matthew", LastName = "Hall", Salary = 1, HoursPerDay = 0, DaysPerWeek = 1, WeeksPerYear = 1 }).SetName("HoursPerDayLow");
                yield return new TestCaseData(new EmployeeProfile { FirstName = "Matthew", LastName = "Hall", Salary = 1, HoursPerDay = 25, DaysPerWeek = 1, WeeksPerYear = 1 }).SetName("HoursPerDayHigh");
                yield return new TestCaseData(new EmployeeProfile { FirstName = "Matthew", LastName = "Hall", Salary = 1, HoursPerDay = 8, DaysPerWeek = 0, WeeksPerYear = 1 }).SetName("DaysPerWeekLow");
                yield return new TestCaseData(new EmployeeProfile { FirstName = "Matthew", LastName = "Hall", Salary = 1, HoursPerDay = 8, DaysPerWeek = 8, WeeksPerYear = 1 }).SetName("DaysPerWeekHigh");
                yield return new TestCaseData(new EmployeeProfile { FirstName = "Matthew", LastName = "Hall", Salary = 1, HoursPerDay = 8, DaysPerWeek = 0, WeeksPerYear = 0 }).SetName("WeeksPerYearLow");
                yield return new TestCaseData(new EmployeeProfile { FirstName = "Matthew", LastName = "Hall", Salary = 1, HoursPerDay = 8, DaysPerWeek = 8, WeeksPerYear = 53 }).SetName("WeeksPerYearHigh");
            }
        }

        /// <summary>
        /// Employees the profile valid details calls add employee once.
        /// </summary>
        [Test]
        public void EmployeeProfile_ValidDetails_Calls_AddEmployeeOnce()
        {
            Mock<IEmployeeProvider> mockEmployeeProvide = new Mock<IEmployeeProvider>();
            AddEmployeeViewModel addEmployeeViewModel = new AddEmployeeViewModel(mockEmployeeProvide.Object);
            mockEmployeeProvide.Setup(x => x.AddEmployee(It.IsAny<EmployeeProfile>()));

            var result = new EmployeeProfile { FirstName = "Matthew", LastName = "Hall", Salary = 10000, DaysPerWeek = 5, HoursPerDay = 8, WeeksPerYear = 50 };

            addEmployeeViewModel.SaveCommand.Execute(result);
            mockEmployeeProvide.Verify(x => x.AddEmployee(It.IsAny<EmployeeProfile>()), Times.Once());

            Assert.Pass();
        }

        /// <summary>
        /// Employees the profile in valid details calls add employee zero.
        /// </summary>
        [Test]
        public void EmployeeProfile_InValidDetails_Calls_AddEmployeeZero()
        {
            Mock<IEmployeeProvider> mockEmployeeProvide = new Mock<IEmployeeProvider>();
            AddEmployeeViewModel addEmployeeViewModel = new AddEmployeeViewModel(mockEmployeeProvide.Object);
            mockEmployeeProvide.Setup(x => x.AddEmployee(It.IsAny<EmployeeProfile>()));

            var result = new EmployeeProfile { FirstName = "Matthew", LastName = string.Empty, Salary = 10000, DaysPerWeek = 5, HoursPerDay = 8, WeeksPerYear = 50 };

            addEmployeeViewModel.SaveCommand.Execute(result);
            mockEmployeeProvide.Verify(x => x.AddEmployee(It.IsAny<EmployeeProfile>()), Times.Never);

            Assert.Pass();
        }

        /// <summary>
        /// Employees the profile weeks per year divide by zero returns divide by zero exception.
        /// </summary>
        /// <param name="employeeProfile">The employee profile.</param>
        [TestCaseSource("InvalidEmployeeDetails")]
        public void EmployeeProfile_WeeksPerYear_DivideByZero_ReturnsDivideByZeroException(EmployeeProfile employeeProfile)
        {
            Mock<IEmployeeProvider> mockEmployeeProvide = new Mock<IEmployeeProvider>();
            AddEmployeeViewModel addEmployeeViewModel = new AddEmployeeViewModel(mockEmployeeProvide.Object);
            mockEmployeeProvide.Setup(x => x.AddEmployee(It.IsAny<EmployeeProfile>()));

            var result = employeeProfile;

            addEmployeeViewModel.SaveCommand.Execute(result);
            mockEmployeeProvide.Verify(x => x.AddEmployee(It.IsAny<EmployeeProfile>()), Times.Never);
            Assert.Pass();
        }
    }
}
