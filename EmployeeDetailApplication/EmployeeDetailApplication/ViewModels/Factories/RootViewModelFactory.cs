using EmployeeDetailApplication.Models.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailApplication.ViewModels.Factories
{
    public class RootViewModelFactory : IRootViewModelFactory
    {
        //Creation of delegates functions to create ViewModels using Dependancy Injection
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<CreateEViewModel> _createCreateViewModel;
        private readonly CreateViewModel<EditEViewModel> _createEditViewModel;

        public RootViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel, 
            CreateViewModel<CreateEViewModel> createCreateViewModel, 
            CreateViewModel<EditEViewModel> createEditViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createCreateViewModel = createCreateViewModel;
            _createEditViewModel = createEditViewModel;
        }

        public BaseViewModel CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _createHomeViewModel();
                case ViewType.Create:
                    return _createCreateViewModel();
                case ViewType.Edit:
                    return _createEditViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
