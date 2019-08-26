namespace EmployeeProfileApp.WPF
{
    using System;
    using System.Windows;
    using MvvmCross.Core.ViewModels;
    using MvvmCross.Platform;
    using MvvmCross.Wpf.Views.Presenters;
    
    /// <summary>
    /// App start up
    /// </summary>
    /// <seealso cref="System.Windows.Application" />
    public partial class App : Application
    {
        /// <summary>
        /// The setup complete
        /// </summary>
        private bool setupComplete;

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Activated" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnActivated(EventArgs e)
        {
            if (!setupComplete)
            {
                DoSetup();
            }

            base.OnActivated(e);
        }

        /// <summary>
        /// Does the setup.
        /// </summary>
        private void DoSetup()
        {
            LoadMvxAssemblyResources();

            var presenter = new MvxSimpleWpfViewPresenter(MainWindow);

            var setup = new Setup(Dispatcher, presenter);
            setup.Initialize();

            var start = Mvx.Resolve<IMvxAppStart>();
            start.Start();

            setupComplete = true;
        }

        /// <summary>
        /// Loads the MVX assembly resources.
        /// </summary>
        private void LoadMvxAssemblyResources()
        {
            for (var i = 0;; i++)
            {
                var key = "MvxAssemblyImport" + i;
                var data = TryFindResource(key);
                if (data == null)
                {
                    return;
                }
            }
        }
    }
}