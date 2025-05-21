using Hat.Domain.Models;
using Hat.ViewModels;

namespace Hat.DataViewModels
{

    public class DeliveryStepViewModel : BaseViewModel
    {
        public DeliveryStepViewModel(DeliveryStepModel data)
        {
            Id= data.Id;
            Name = data.Name;
            Location = data.Location;
            IsComplete = data.IsComplete;
            IsLineVisible = data.IsLineVisible;
            DeliveryStatusDate = data.DeliveryStatusDate;

        }
        public Guid Id { get; set; }
        private string _Name;
        public string Name
        {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }
        private string _Location;
        public string Location
        {
            get => _Location;
            set => SetProperty(ref _Location, value);
        }
        private DateTime _DeliveryStatusDate;
        public DateTime DeliveryStatusDate
        {
            get => _DeliveryStatusDate;
            set => SetProperty(ref _DeliveryStatusDate, value);
        }       

        private bool _IsComplete;
        public bool IsComplete
        {
            get => _IsComplete;
            set
            {
                if (_IsComplete != value)
                {
                    _IsComplete = value;
                    OnPropertyChanged(nameof(IsComplete));
                    OnPropertyChanged(nameof(StatusColor));
                    OnPropertyChanged(nameof(IsLineVisible));
                }
            }

        }


        private bool _IsLineVisible = true;
        public bool IsLineVisible
        {
            get => _IsLineVisible;
            set => SetProperty(ref _IsLineVisible, value);
        }


        public Color StatusColor
        => IsComplete ? Color.FromArgb("#00C569") : Color.FromArgb("#C8C8C8");
    }
}