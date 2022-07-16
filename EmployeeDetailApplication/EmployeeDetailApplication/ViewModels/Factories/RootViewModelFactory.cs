using EmployeeDetailApplication.Models.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailApplication.ViewModels.Factories
{
    public class RootViewModelFactory : IRootViewModelFactory
    {
        private readonly IViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly IViewModelFactory<SearchEViewModel> _searchViewModelFactory;
        private readonly IViewModelFactory<CreateEViewModel> _createViewModelFactory;
        private readonly IViewModelFactory<DeleteEViewModel> _deleteViewModelFactory;
        private readonly IViewModelFactory<EditEViewModel> _editViewModelFactory;

        public RootViewModelFactory(IViewModelFactory<HomeViewModel> homeViewModelFactory,
            IViewModelFactory<SearchEViewModel> searchViewModelFactory,
            IViewModelFactory<CreateEViewModel> createViewModelFactory,
            IViewModelFactory<DeleteEViewModel> deleteViewModelFactory,
            IViewModelFactory<EditEViewModel> editViewModelFactory)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _searchViewModelFactory = searchViewModelFactory;
            _createViewModelFactory = createViewModelFactory;
            _deleteViewModelFactory = deleteViewModelFactory;
            _editViewModelFactory = editViewModelFactory;
        }
        public BaseViewModel CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.Search:
                    return _searchViewModelFactory.CreateViewModel();
                case ViewType.Create:
                    return _createViewModelFactory.CreateViewModel();
                case ViewType.Delete:
                    return _deleteViewModelFactory.CreateViewModel();
                case ViewType.Edit:
                    return _editViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
