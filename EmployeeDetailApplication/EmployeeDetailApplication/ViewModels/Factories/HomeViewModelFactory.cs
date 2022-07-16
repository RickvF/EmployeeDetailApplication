using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailApplication.ViewModels.Factories
{
    public class HomeViewModelFactory : IViewModelFactory<HomeViewModel>
    {
        public HomeViewModelFactory()
        {

        }
        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel();
        }
    }
}
