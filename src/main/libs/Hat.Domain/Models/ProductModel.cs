using Hat.Model;

namespace Hat.Domain.Models
{

    public class ProductModel :IUserModel
    {
      
        #region data
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid CustomerId { get; set; }

        public Guid VatId { get; set; }

        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public string Details { get; set; }




        #endregion

        #region rich
        public List<ReviewModel> Reviews { get; set; } = new List<ReviewModel>();
        public TaxModel Vat { get; set; } = new TaxModel();

        public List<ProductOptionModel> Options { get; set; } = new List<ProductOptionModel>();
      
        public List<string> ProductSizes { get;  set; }//sourced from inventory
        public List<string> ProductColors { get;  set; }//sourced from inventory

        public double Qty { get; set; } //sourced from inventory

        public bool IsAvailable => Qty > 0;

        public double VatRate=>Vat.Rate;
        public string VatCode => Vat.Code;
       
        #endregion

    }
}
