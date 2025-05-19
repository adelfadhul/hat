using Hat.Domain.Models;
using Hat.ViewModels;

namespace Hat.DataViewModels
{
    public class DeliveryTypeViewModel : BaseViewModel
    {
        public DeliveryTypeViewModel()
        {

        }
        public DeliveryTypeViewModel(DeliveryTypeModel data)
        {
            Name = data.Name;
            Description = data.Description;
            IsSelected = data.IsSelected;
        }
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
