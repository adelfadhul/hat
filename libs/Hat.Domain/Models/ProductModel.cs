using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hat.Domain.Models
{
    public class ProductModel
    {

        #region data
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public double Price { get; set; }
        public string Details { get; set; }
        public double Qty { get; set; } 
        public bool IsAvailable { get; set; }
        #endregion

        #region rich
       
        #endregion

    }
}
