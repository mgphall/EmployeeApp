namespace EmployeeProfileApp.WPF
{
    using System.Windows;
    using System.Windows.Controls;
    using EmployeeProfileApp.Core.ExtensionMethod;
    using EmployeeProfileApp.Core.Models;

    /// <summary>
    /// Interaction logic for EmployeeDetails
    /// </summary>
    public partial class EmployeeDetails : UserControl
    {
        /// <summary>
        /// The employee property
        /// </summary>
        public static readonly DependencyProperty EmployeeProperty = DependencyProperty.Register("Employee", typeof(EmployeeProfile),
                typeof(EmployeeDetails), new FrameworkPropertyMetadata(null, OnEmployeePropertyChanged));

        /// <summary>
        /// The weekly rate property key
        /// </summary>
        private static readonly DependencyPropertyKey WeeklyRatePropertyKey  = DependencyProperty.RegisterReadOnly("WeeklyRate", typeof(decimal),
            typeof(EmployeeDetails), new FrameworkPropertyMetadata(default(decimal), FrameworkPropertyMetadataOptions.None));

        /// <summary>
        /// The weekly rate property
        /// </summary>
        public static readonly DependencyProperty WeeklyRateProperty  = WeeklyRatePropertyKey.DependencyProperty;

        /// <summary>
        /// The daily rate property key
        /// </summary>
        private static readonly DependencyPropertyKey DailyRatePropertyKey = DependencyProperty.RegisterReadOnly("DailyRate", typeof(decimal), 
            typeof(EmployeeDetails), new FrameworkPropertyMetadata(default(decimal), FrameworkPropertyMetadataOptions.None));
       
        /// <summary>
        /// The daily rate property
        /// </summary>
        public static readonly DependencyProperty DailyRateProperty  = DailyRatePropertyKey.DependencyProperty;

        /// <summary>
        /// The hourly rate property key
        /// </summary>
        private static readonly DependencyPropertyKey HourlyRatePropertyKey = DependencyProperty.RegisterReadOnly("HourlyRate", typeof(decimal), 
            typeof(EmployeeDetails), new FrameworkPropertyMetadata(default(decimal), FrameworkPropertyMetadataOptions.None));

        /// <summary>
        /// The hourly rate property
        /// </summary>
        public static readonly DependencyProperty HourlyRateProperty = HourlyRatePropertyKey.DependencyProperty;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeDetails"/> class.
        /// </summary>
        public EmployeeDetails()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        public EmployeeProfile Employee
        {
            get { return (EmployeeProfile)GetValue(EmployeeProperty); }
            set { SetValue(EmployeeProperty, value); }
        }

        /// <summary>
        /// Gets or sets the weekly rate.
        /// </summary>
        public decimal WeeklyRate
        {
            get { return (decimal)GetValue(WeeklyRateProperty); }
            protected set { SetValue(WeeklyRatePropertyKey, value); }
        }

        /// <summary>
        /// Gets or sets the daily rate.
        /// </summary>
        public decimal DailyRate
        {
            get { return (decimal)GetValue(DailyRateProperty); }
            protected set { SetValue(DailyRatePropertyKey, value); }
        }

        /// <summary>
        /// Gets or sets the hourly rate.
        /// </summary>
        public decimal HourlyRate
        {
            get { return (decimal)GetValue(HourlyRateProperty); }
            protected set { SetValue(HourlyRatePropertyKey, value); }
        }

        /// <summary>
        /// Called when [employee property changed].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnEmployeePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            EmployeeDetails c = d as EmployeeDetails;
            c?.OnEmployeeChanged();
        }

        /// <summary>
        /// Called when [employee changed].
        /// </summary>
        private void OnEmployeeChanged()
        {
            if (Employee != null)
            {
                var rates = Employee.CalculateRates();

                WeeklyRate = rates.weeklyRate;
                DailyRate = rates.dailyRate;
                HourlyRate = rates.hourlyRate;
            }
        }
    }
}