using Hat.Domain.Commands;
using Hat.Domain.Features.Product.Enums;
using Hat.Domain.Features.Product.Models;
using Hat.Domain.Features.Product.Store;
using Hat.Domain.Features.Product.Types.Extended;
using Hat.Domain.Features.Product.Types.Grouped;
using Hat.Domain.Features.Product.Types.Physical;
using Hat.Domain.Features.Product.Types.Variable;
using Hat.Domain.Features.Product.Types.Virtual;
using MediatR;

namespace Hat.Application.Features.Product.Commands
{
    internal class CreateProductCommandHandler : IRequest<Guid>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
          
            return await _productRepository.CreateProduct(getProduct(request));
        }

        private ProductModel getProduct(CreateProductCommand request)
        {
            ProductModel product;
            switch (request.ProductType)
            {
                case ProductType.Variable:
                    product = new VariableProductModel(request.Name, request.Description, request.Categories)
                    {
                        Variations = request.Variations

                    };
                    break;
                case ProductType.Virtual:
                    product = new VirtualProductModel(request.Name, request.Description, request.Categories)
                    {
                        Price = request.Price,
                        DownloadUrl = request.DownloadUrl, // Assuming ImageUrl is used for download URL in virtual products
                    };
                    break;
                case ProductType.Physical:
                    product = new PhysicalProductModel(request.Name, request.Description, request.Categories)
                    {
                        Price = request.Price,
                        StockQuantity = request.StockQuantity, // Assuming Weight is a property in PhysicalProductModel
                        WeightKg = request.WeightKg, // Assuming Weight is a property in PhysicalProductModel
                        LengthCm = request.LengthCm, // Assuming Length is a property in PhysicalProductModel
                        WidthCm = request.WidthCm, // Assuming Width is a property in PhysicalProductModel
                        HeightCm = request.HeightCm, // Assuming Height is a property in PhysicalProductModel
                    };
                    break;
                case ProductType.Grouped:
                    product = new GroupedProductModel(request.Name, request.Description)
                    {
                        // Assuming Categories is a property in GroupedProductModel
                        ChildProductIds = request.ChildProductIds // Assuming GroupedProducts is a property in GroupedProductModel
                    };
                    break;
                case ProductType.Extended:
                    product = new ExtendedProductModel(request.Name, request.Description)
                    {

                    };
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(request.ProductType), "Unsupported product type");
            }


            return product;
        }
    }
}
