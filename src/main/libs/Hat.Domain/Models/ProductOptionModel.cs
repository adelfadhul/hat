using Hat.Domain.Enums;
using Hat.Domain.Helpers;

namespace Hat.Domain.Models
{

    public class ProductOptionModel
    {

        #region data
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public ProductOptionValueType ValueType { get; set; }



        #endregion

        #region rich

        public List<ProductOptionSelectionModel>? Selections { get; set; } = [];
        #endregion
    }
}
