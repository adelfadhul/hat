namespace Hat.Domain.Models
{
    public class TrackModel
    {
       
        #region data

        public Guid Id { get; set; }
        public string OrderId { get; set; }

        public string Price { get; set; }

        public string Status { get; set; }

        public string ImageUrls { get; set; }

        #endregion

        #region rich
        public List<string> ImageUrlList => ImageUrls.Split(',').ToList();
        public int NumberOfItems => ImageUrlList.Count;
        public bool ImageOneVisibility => NumberOfItems >= 1;
        public string ImageOneUrl => ImageUrlList[0];
        public bool ImageTwoVisibility => NumberOfItems >= 2;
        public string ImageTwoUrl => ImageUrlList[1];
        public bool ImageThreeVisibility => NumberOfItems >= 3;
        public string ImageThreeUrl => ImageUrlList[2];
        public bool ImageMoreVisibility => NumberOfItems >= 4;
        public int RemainingImages => NumberOfItems - 3;
        public override string ToString()
        {
            return OrderId;
        }
        #endregion
    }
}
