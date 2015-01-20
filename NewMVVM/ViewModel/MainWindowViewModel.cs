using System.Collections.ObjectModel;
using NewMVVM.DataAccess;

namespace NewMVVM.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        readonly EmployeeRepository _employeeRepository;

        ObservableCollection<ViewModelBase> _viewModels;

        public MainWindowViewModel()
        {
            _employeeRepository = new EmployeeRepository();
            //create an instance of our viewmodel add it to our collection
            EmployeeListViewModel viewModel = new EmployeeListViewModel(_employeeRepository);
            this.ViewModels.Add(viewModel);
        }

        public ObservableCollection<ViewModelBase> ViewModels
        {
            get
            {
                if (_viewModels == null)
                {
                    _viewModels = new ObservableCollection<ViewModelBase>();
                }
                return _viewModels;
            }
        }
    }
}
