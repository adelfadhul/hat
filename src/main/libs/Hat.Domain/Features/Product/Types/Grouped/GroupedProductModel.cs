using Hat.Domain.Features.Product.Enums;
using Hat.Domain.Features.Product.Models;

namespace Hat.Domain.Features.Product.Types.Grouped
{
    public class GroupedProductModel : ProductModel
    {
        #region data
        #endregion

        #region rich
        public override ProductType Type => ProductType.Grouped;

        public ICollection<Guid> ChildProductIds { get;  set; }
        #endregion
        public GroupedProductModel(string name, string? description)
            : base(name,description)
        {

        }
        public GroupedProductModel(string name, string? description, ICollection<Guid> children)
            : base(name, description)
        {
            ChildProductIds = children ?? new List<Guid>();
        }
    }
}
