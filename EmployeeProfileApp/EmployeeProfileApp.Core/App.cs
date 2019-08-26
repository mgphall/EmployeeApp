namespace EmployeeProfileApp.Core
{
    using EmployeeProfileApp.Core.Provider;
    using Microsoft.EntityFrameworkCore;
    using MvvmCross.Platform.IoC;

    /// <summary>
    /// App start
    /// </summary>
    /// <seealso cref="MvvmCross.Core.ViewModels.MvxApplication" />
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        /// <summary>Initializes this instance.</summary>
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Provider")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterNavigationServiceAppStart<ViewModels.MainMenuViewModel>();

            using (var databaseContext = new DatabaseContext())
            {
                databaseContext.Database.Migrate();
            }
        }
    }
}
