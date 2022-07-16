using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailApplication.ViewModels.Factories
{
    public class CreateEViewModelFactory : IViewModelFactory<CreateEViewModel>
    {
        public CreateEViewModel CreateViewModel()
        {
            return new CreateEViewModel();
        }
    }
}
