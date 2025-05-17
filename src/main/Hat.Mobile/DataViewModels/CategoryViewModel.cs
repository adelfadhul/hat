using Hat.Domain.Models;

namespace Hat.DataViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            CategoryID = 0;
            CategoryName = string.Empty;
            Icon = string.Empty;
        }
        public CategoryViewModel(CategoryModel domainModel)
        {
            CategoryID = domainModel.CategoryID;
            CategoryName = domainModel.CategoryName;
            Icon = domainModel.Icon;
        }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Icon { get; set; }


    }
}
