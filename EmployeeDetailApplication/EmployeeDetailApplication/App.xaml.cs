using EmployeeDetailApplication.Models.Navigators;
using EmployeeDetailApplication.ViewModels;
using EmployeeDetailApplication.ViewModels.Factories;
using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using EmployeeDetailApplication.Services;
using EmployeeDetailApplication.Commands;

namespace EmployeeDetailApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            //Only create Httpclient once over the entire application
            services.AddHttpClient("employeeDataHttpClient");

            //Register Services
            services.AddSingleton<IEmployeeDataService, EmployeeDataService>();
            services.AddSingleton<SelectedEmployeeStorageService, SelectedEmployeeStorageService>();

            //Register Factory
            services.AddSingleton<IRootViewModelFactory, RootViewModelFactory>();


            //Register ViewModels
            //Recreate HomeViewModel everytime, so the overview will get updated on redirect from Edit and Create view.
            //Implementation of the delegate
            services.AddSingleton<CreateViewModel<HomeViewModel>>(s =>
            {
                return () => new HomeViewModel(EmployeeOverViewViewModel.LoadEmployeeOverViewViewModel(
                    s.GetRequiredService<IEmployeeDataService>(),
                    s.GetRequiredService<ViewModelDelegateRenavigator<EditEViewModel>>(),
                    s.GetRequiredService<SelectedEmployeeStorageService>()));
            });

            //Recreate CreateEViewModel everytime so an empty Employee will be created which can be filled in by the user
            //Implementation of the delegate
            services.AddSingleton<CreateViewModel<CreateEViewModel>>(s => 
            {
                return () => new CreateEViewModel(s.GetRequiredService<IEmployeeDataService>(),
                    s.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>());
            });

            //Recreate EditEViewModel everytime, to obtain Selected Employee
            //Implementation of the delegate
            services.AddSingleton<CreateViewModel<EditEViewModel>>(s =>
            {
                return () => new EditEViewModel(s.GetRequiredService<IEmployeeDataService>(),
                    s.GetRequiredService<SelectedEmployeeStorageService>(),
                    s.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>());
            });

            //Register Navigators/ Renavigators
            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
            services.AddSingleton<ViewModelDelegateRenavigator<EditEViewModel>>();

            //Register Main
            services.AddScoped<MainViewModel>();
            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
