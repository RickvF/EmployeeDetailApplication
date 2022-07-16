using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailApplication.ViewModels.Factories
{
    public class HomeViewModelFactory : IViewModelFactory<HomeViewModel>
    {
        private IViewModelFactory<EmployeeOverViewViewModel> _employeOverViewViewModelFactory;
        public HomeViewModelFactory(IViewModelFactory<EmployeeOverViewViewModel> employeOverViewViewModelFactory)
        {
            _employeOverViewViewModelFactory = employeOverViewViewModelFactory;
        }
        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel(_employeOverViewViewModelFactory.CreateViewModel());
        }
    }
}
