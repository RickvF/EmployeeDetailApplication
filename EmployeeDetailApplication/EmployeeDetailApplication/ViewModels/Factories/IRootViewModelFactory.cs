using EmployeeDetailApplication.Models.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailApplication.ViewModels.Factories
{
    public interface IRootViewModelFactory
    {
        BaseViewModel CreateViewModel(ViewType viewType);
    }
}
