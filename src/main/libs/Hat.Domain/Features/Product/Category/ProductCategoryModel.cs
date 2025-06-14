namespace Hat.Domain.Features.Product.Category
{
    public class ProductCategoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Slug { get; set; } // like "electronics", "mens-shoes"
    }
}
