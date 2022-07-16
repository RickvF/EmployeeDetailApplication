using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailApplication.ViewModels.Factories
{
    public class SearchEViewModelFactory : IViewModelFactory<SearchEViewModel>
    {
        public SearchEViewModel CreateViewModel()
        {
            return new SearchEViewModel();
        }
    }
}
