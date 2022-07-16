using EmployeeDetailApplication.Models.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailApplication.ViewModels.Factories
{
    public class RootViewModelFactory : IRootViewModelFactory
    {
        private readonly IViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly IViewModelFactory<CreateEViewModel> _createViewModelFactory;
        private readonly IViewModelFactory<EditEViewModel> _editViewModelFactory;

        public RootViewModelFactory(IViewModelFactory<HomeViewModel> homeViewModelFactory,
            IViewModelFactory<CreateEViewModel> createViewModelFactory,
            IViewModelFactory<EditEViewModel> editViewModelFactory)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _createViewModelFactory = createViewModelFactory;
            _editViewModelFactory = editViewModelFactory;
        }
        public BaseViewModel CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.Create:
                    return _createViewModelFactory.CreateViewModel();
                case ViewType.Edit:
                    return _editViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
