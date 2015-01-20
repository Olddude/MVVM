using System;
using System.Collections.ObjectModel;
using NewMVVM.DataAccess;
using System.Windows.Input;
using System.Windows.Media;

namespace NewMVVM.ViewModel
{
    public class EmployeeListViewModel : ViewModelBase
    {
        readonly EmployeeRepository _employeeRepository;

        RelayCommand _invasionCommand;

        public ObservableCollection<Model.Employee> AllEmployees { get; private set; }

        public EmployeeListViewModel(EmployeeRepository employeeRepository)
        {
            if (employeeRepository == null)
            {
                throw new ArgumentNullException("employeeRepository");
            }

            _employeeRepository = employeeRepository;
            this.AllEmployees = new ObservableCollection<Model.Employee>(_employeeRepository.GetEmployees());
        }

        protected override void OnDispose()
        {
            this.AllEmployees.Clear();
        }

        private Brush _bgBrush;
        public Brush BackgroundBrush
        {
            get
            {
                return _bgBrush;
            }
            set
            {
                _bgBrush = value;
                OnPropertyChanged("BackGroundBrush");
            }
        }

        public ICommand InvasionCommand
        {
            get
            {
                if (_invasionCommand == null)
                {
                    _invasionCommand = new RelayCommand(param => this.InvasionCommandExecute(), param => this.InvasionCommandCanExecute);
                }
                return _invasionCommand;
            }
        }

        void InvasionCommandExecute()
        {
            bool isInvasion = true;
            foreach (Model.Employee emp in this.AllEmployees)
            {
                if (emp.LastName.Trim().ToLower() != "smith")
                {
                    isInvasion = false;
                }
            }
            if (isInvasion)
            {
                BackgroundBrush = new SolidColorBrush(Colors.Green);
            }
            else
            {
                BackgroundBrush = new SolidColorBrush(Colors.White);
            }
        }

        bool InvasionCommandCanExecute
        {
            get
            {
                if (this.AllEmployees.Count == 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
