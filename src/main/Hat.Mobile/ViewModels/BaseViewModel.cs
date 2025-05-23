using Hat.Mobile.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Hat.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected NavigationService _navigationService;
        protected DataService _dataService;
        public BaseViewModel(NavigationService navigationService, DataService dataService) {
            _navigationService = navigationService;
            _dataService = dataService;
        }
        public BaseViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value,Action onChanged = null, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
