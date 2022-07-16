using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailApplication.ViewModels.Factories
{
    public class DeleteEViewModelFactory : IViewModelFactory<DeleteEViewModel>
    {
        public DeleteEViewModel CreateViewModel()
        {
            return new DeleteEViewModel();
        }
    }
}
