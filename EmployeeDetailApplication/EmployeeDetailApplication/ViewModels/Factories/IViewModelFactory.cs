using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailApplication.ViewModels.Factories
{
    public interface IViewModelFactory<BaseViewModel>
    {
        BaseViewModel CreateViewModel();
    }
}
