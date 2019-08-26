namespace EmployeeProfileApp.Core.ExtensionMethod
{
    using System;
    using Models;

    /// <summary>
    /// Employee Extension methods
    /// </summary>
    public static class EmployeeExtension
    {
        /// <summary>
        /// Calculates the rates.
        /// </summary>
        /// <param name="ep">The ep.</param>
        /// <returns> weekly rates</returns>
        /// <exception cref="DivideByZeroException">
        /// You can't divide WeeksPerYear by Zero!
        /// or
        /// You can't divide DaysPerWeek by Zero!
        /// or
        /// You can't divide HoursPerDay by Zero!
        /// </exception>
        public static (decimal weeklyRate, decimal dailyRate, decimal hourlyRate) CalculateRates(this EmployeeProfile ep)
        {
            if (ep.WeeksPerYear == 0)
            {
                throw new DivideByZeroException("You can't divide WeeksPerYear by Zero!");
            }

            if (ep.DaysPerWeek == 0)
            {
                throw new DivideByZeroException("You can't divide DaysPerWeek by Zero!");
            }

            if (ep.HoursPerDay == 0)
            {
                throw new DivideByZeroException("You can't divide HoursPerDay by Zero!");
            }

            var weeklyRate = ep.Salary / ep.WeeksPerYear;
           var dailyRate = weeklyRate / ep.DaysPerWeek;
           var hourlyRate = dailyRate / ep.HoursPerDay;

           return (weeklyRate, dailyRate, hourlyRate);
        }
    }
}