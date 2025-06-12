using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    internal class ProductByIdQueryHandler : IRequestHandler<ProductByIdQuery, ProductModel?>
    {
        private readonly IProductRepository _productRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly ITaxRepository _vatRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IProductOptionRepository _productOptionRepository;
        private readonly IProductOptionSelectionRepository _productOptionSelectionRepository;
        public ProductByIdQueryHandler(IProductRepository productRepository, IReviewRepository reviewRepository, ITaxRepository vatRepository, IInventoryRepository inventoryRepository, IProductOptionRepository productOptionRepository, IProductOptionSelectionRepository productOptionSelectionRepository)
        {
            _productRepository = productRepository;
            _reviewRepository = reviewRepository;
            _vatRepository = vatRepository;
            _inventoryRepository = inventoryRepository;
            _productOptionRepository = productOptionRepository;
            _productOptionSelectionRepository = productOptionSelectionRepository;
        }

        public async Task<ProductModel?> Handle(ProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(request.ProductId);
            if (product is null) return null;

            var vat = await _vatRepository.GetVat(product?.VatId ?? Guid.Empty);
            if(vat is not null)
            {
                product.Vat = vat;
            }

            var availableQty = await _inventoryRepository.GetCountByProduct(request.ProductId);
            product.Qty = availableQty; 
            if (availableQty > 0)
            {
                var colors = await _inventoryRepository.GetColorsByProduct(request.ProductId);
                product.ProductColors = colors;



                var sizes = await _inventoryRepository.GetSizesByProduct(request.ProductId);
                product.ProductSizes = sizes;
            }

           
            var options = await _productOptionRepository.GetProductOptionsByProduct(request.ProductId);
            
            if (options is not null && options.Count > 0)
            {
                
                foreach (var option in options)
                {
                    var selections = await _productOptionSelectionRepository.GetProductOptionSelectionsByOption(option.Id);
                    option.Selections = selections.Where(s => s.ProductOptionId == option.Id).ToList();
                }
                product.Options = options;
            }
           


            if (request.IsFull && product is not null)
                product.Reviews = await _reviewRepository.GetReviewsByProduct(product.Id);

            return product;

        }

    }
}
