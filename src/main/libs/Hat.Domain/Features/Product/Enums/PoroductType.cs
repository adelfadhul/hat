namespace Hat.Domain.Features.Product.Enums
{
    public enum ProductType
    {
        None,
        Physical,// a unique physical product that you may have to ship to the customer
        Virtual,// aunique digital product like services, downloadable books, music or videos
        Variable, // a product with multiple options like size or color
        Grouped, // a collection of related products sold together
        Extended, // a product with additional features or options
    }



}
