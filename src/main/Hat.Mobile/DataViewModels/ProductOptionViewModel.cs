using Hat.Domain.Enums;
using Hat.Domain.Models;
using Hat.Mobile.ViewModels;

namespace Hat.DataViewModels
{
    public class ProductOptionViewModel: BaseViewModel
    {
        public ProductOptionViewModel(ProductOptionModel data)
        {
            Id = data.Id;
            Name = data.Name;
            ValueType = data.ValueType;
            data.Selections?.ForEach(x =>
            {
                if (x is not null)
                {
                    Selections.Add(x.Value);
                }
            });
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProductOptionValueType ValueType { get; set; }


        private List<string> selections= new();
        public List<string> Selections 
        { 
            get=>selections;
            set
            {
                if (selections != value)
                {
                    selections = value;
                    OnPropertyChanged(nameof(Selections));
                }
            }
        } 
    }
}
