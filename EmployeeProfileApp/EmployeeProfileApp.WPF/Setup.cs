namespace EmployeeProfileApp.WPF
{
    using System.Windows.Threading;
    using MvvmCross.Core.ViewModels;
    using MvvmCross.Platform.Platform;
    using MvvmCross.Wpf.Platform;
    using MvvmCross.Wpf.Views.Presenters;

    /// <summary>
    /// application Setup
    /// </summary>
    /// <seealso cref="MvvmCross.Wpf.Platform.MvxWpfSetup" />
    public class Setup : MvxWpfSetup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Setup"/> class.
        /// </summary>
        /// <param name="dispatcher">The dispatcher.</param>
        /// <param name="presenter">The presenter.</param>
        public Setup(Dispatcher dispatcher, IMvxWpfViewPresenter presenter)
            : base(dispatcher, presenter)
        {
         }

        /// <summary>
        /// Creates the application.
        /// </summary>
        /// <returns> create Application</returns>
        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        /// <summary>
        /// Creates the debug trace.
        /// </summary>
        /// <returns>Create Debug Trace</returns>
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}
