using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailApplication.ViewModels.Factories
{
    public class EditEViewModelFactory : IViewModelFactory<EditEViewModel>
    {
        public EditEViewModel CreateViewModel()
        {
            return new EditEViewModel();
        }
    }
}
