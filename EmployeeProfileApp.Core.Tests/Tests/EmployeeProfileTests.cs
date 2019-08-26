namespace EmployeeProfileApp.Core.Tests.Tests
{
    using System;
    using System.Collections.Generic;
    using EmployeeProfileApp.Core.ExtensionMethod;
    using EmployeeProfileApp.Core.Models;
    using NUnit.Framework;

    /// <summary>
    /// Employee Profile Tests
    /// </summary>
    public class EmployeeProfileTests
    {
        /// <summary>
        /// Gets the divide by zero exception divide by zero exception.
        /// </summary>
        public static IEnumerable<TestCaseData> DivideByZeroExceptionDivideByZeroException
        {
            get
            {
                yield return new TestCaseData(new EmployeeProfile { FirstName = "Matthew", LastName = "Hall", Salary = 10000, DaysPerWeek = 1, HoursPerDay = 1, WeeksPerYear = 0 }, "You can't divide WeeksPerYear by Zero!").SetName("WeeksPerYear");
                yield return new TestCaseData(new EmployeeProfile { FirstName = "Matthew", LastName = "Hall", Salary = 0, HoursPerDay = 1, DaysPerWeek = 0, WeeksPerYear = 1 }, "You can't divide DaysPerWeek by Zero!").SetName("DaysPerWeek");
                yield return new TestCaseData(new EmployeeProfile { FirstName = "Matthew", LastName = "Hall", Salary = 0, HoursPerDay = 0, DaysPerWeek = 1, WeeksPerYear = 1 }, "You can't divide HoursPerDay by Zero!").SetName("HoursPerDay");
            }
        }

        /// <summary>
        /// Employees the profile valid details returns correct rates.
        /// </summary>
        [Test]
        public void EmployeeProfile_ValidDetails_ReturnsCorrectRates()
        {
            var result = new EmployeeProfile { FirstName = "Matthew", LastName = "Hall", Salary = 10000, DaysPerWeek = 5, HoursPerDay = 8, WeeksPerYear = 50 };

            var (weeklyRate, dailyRate, hourlyRate) = result.CalculateRates();
             
            Assert.AreEqual(weeklyRate, 200);
            Assert.AreEqual(dailyRate, 40);
            Assert.AreEqual(hourlyRate, 5);
        }

        /// <summary>
        /// Employees the profile weeks per year divide by zero returns divide by zero exception.
        /// </summary>
        /// <param name="employeeProfile">The employee profile.</param>
        /// <param name="expectedMessage">The expected message.</param>
        [TestCaseSource("DivideByZeroExceptionDivideByZeroException")]
        public void EmployeeProfile_WeeksPerYear_DivideByZero_ReturnsDivideByZeroException(EmployeeProfile employeeProfile, string expectedMessage)
        {
            var result = employeeProfile;

            var ex = Assert.Throws<DivideByZeroException>(() => result.CalculateRates());
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));

            Assert.Pass();
        }
    }
    }