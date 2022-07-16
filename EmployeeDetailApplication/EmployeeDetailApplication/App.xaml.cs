using EmployeeDetailApplication.Models.Navigators;
using EmployeeDetailApplication.ViewModels;
using EmployeeDetailApplication.ViewModels.Factories;
using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using EmployeeDetailApplication.Services;

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

            services.AddSingleton<IEmployeeDataService, EmployeeDataService>();

            services.AddSingleton<IRootViewModelFactory, RootViewModelFactory>();
            services.AddSingleton<IViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<IViewModelFactory<CreateEViewModel>, CreateEViewModelFactory>();
            services.AddSingleton<IViewModelFactory<EditEViewModel>, EditEViewModelFactory>();
            services.AddSingleton<IViewModelFactory<EmployeeOverViewViewModel>, EmployeeOverviewViewModelFactory>();

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
