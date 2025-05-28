using Hat.Model;

namespace Hat.Domain.Models
{
    public class ProductModel 
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
        public double Price { get; set; }
        public string Details { get; set; }
        public double Qty { get; set; }
        public bool IsAvailable { get; set; }

        public string ColorText { get; set; }
        public string SizesText { get; set; }

       
        public List<ReviewModel> Reviews { get; set; } = new List<ReviewModel>();
        public VatModel Vat { get; set; } = new VatModel();
        #endregion

        #region rich
        public List<string> Sizes =>
            SizesText.Split(",").Select(x => x.Trim()).ToList();

        public double VatRate=>Vat.Rate;
        public string VatCode => Vat.Code;
        #endregion

    }
}
