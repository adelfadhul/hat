using Hat.Helpers;
using Hat.Helpers.ExtensionMethods;
using Hat.ViewModel;

namespace Hat.Model
{
    public class CardInfoModel : BaseViewModel
    {
        public CardInfoModel() { }
        public CardInfoModel(Domain.Models.CardInfoModel domainModel)
        {
            CardNumber = domainModel.CardNumber;
            NameOnCard = domainModel.NameOnCard;
            CardValidationCode = domainModel.CardValidationCode;
            ExpirationDate = domainModel.ExpirationDate;
            IsSelected = domainModel.IsSelected;
            CardType= domainModel.CardType;
            MaskedCardNumber = domainModel.MaskedCardNumber;
        }
        public string CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public string CardValidationCode { get; set; }
        public string ExpirationDate { get; set; }

        private bool _IsSelected = false;
        public bool IsSelected
        {
            get => _IsSelected;
            set => SetProperty(ref _IsSelected, value);
        }
        public string CardType { get; init; }

        public Color CardColor
        {
            get
            {
                switch (CardType)
                { 
                     case "American Express":
                        return "AmericanExpress".ToColorFromResourceKey();
                     case "Diners Club":
                        return "DinersClub".ToColorFromResourceKey();
                     case "Discover":
                        return "Discover".ToColorFromResourceKey();
                     case "JCB":
                        return "JCB".ToColorFromResourceKey();
                     case "Master Card":
                        return "MasterCard".ToColorFromResourceKey();
                    case "Visa":
                        return "Visa".ToColorFromResourceKey();
                     default:
                        return "Default".ToColorFromResourceKey();
                }
            }
        }

        public string Icon
        {
            get
            {
                switch (CardType)
                {
                    case "American Express":
                        return "\uf1f3";
                    case "Diners Club":
                        return "\uf24c";
                    case "Discover":
                        return "\uf1f2";
                    case "JCB":
                        return "\uf24b";
                    case "Master Card":
                        return "\uf1f1";
                    case "Visa":
                        return "\uf1f0";
                    default:
                        return "\uf09d";
                }
            }
        }
        public string FontFamily
        {
            get
            {
                if (CardType == "American Express" ||
                    CardType == "Diners Club" ||
                    CardType == "Discover" ||
                    CardType == "JCB" ||
                    CardType == "Master Card" ||
                    CardType == "Visa")
                {
                    return "FA6Brands";
                }
                else
                {
                    return "FA6Regular";
                }                
            }
        }
        public string MaskedCardNumber { get; init; }


    }
}
