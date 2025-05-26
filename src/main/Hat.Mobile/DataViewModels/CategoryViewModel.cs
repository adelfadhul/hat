using Hat.Domain.Models;
using Hat.Infrastructure.Persistance.SqlServer.Entities;

namespace Hat.DataViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            CategoryID = Guid.Empty;
            CategoryName = string.Empty;
            Icon = string.Empty;
        }
        public CategoryViewModel(CategoryModel domainModel)
        {
            CategoryID = domainModel.Id;
            CategoryName = domainModel.Name;
            Icon = domainModel.Icon;
        }
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Icon { get; set; }


    }
}
