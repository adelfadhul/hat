using Hat.ViewModels;

namespace Hat.DataViewModels
{
    public class DeliveryTypeViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        private bool _IsSelected = false;
        public bool IsSelected
        {
            get => _IsSelected;
            set => SetProperty(ref _IsSelected, value);
        }
    }
}
