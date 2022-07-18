using EmployeeDetailApplication.ViewModels;
using EmployeeDetailApplication.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailApplication.Models.Navigators
{
    public class ViewModelDelegateRenavigator<T> : IRenavigator where T : BaseViewModel
    {
        private readonly INavigator _navigator;
        private readonly CreateViewModel<T> _createViewModel;

        public ViewModelDelegateRenavigator(INavigator navigator, CreateViewModel<T> createViewModel)
        {
            _navigator = navigator;
            _createViewModel = createViewModel;
        }

        public void Renavigate()
        {
            _navigator.CurrentViewModel = _createViewModel();
        }
    }
}
