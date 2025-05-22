using Hat.Domain.Constants;
using Hat.Domain.Models;
using Hat.Helpers.ExtensionMethods;
using Hat.ViewModels;

namespace Hat.DataViewModels
{
    public class CardInfoViewModel : BaseViewModel
    {
        public CardInfoViewModel() { }
        public CardInfoViewModel(CardInfoModel domainModel)
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
                    case CardTypes.AmericanExpress:
                        return "\uf1f3";
                    case CardTypes.DinersClub:
                        return "\uf24c";
                    case CardTypes.Discover:
                        return "\uf1f2";
                    case CardTypes.JCB:
                        return "\uf24b";
                    case CardTypes.MasterCard:
                        return "\uf1f1";
                    case CardTypes.Visa:
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
                if (CardType == CardTypes.AmericanExpress ||
                    CardType == CardTypes.DinersClub ||
                    CardType == CardTypes.Discover ||
                    CardType == CardTypes.JCB ||
                    CardType == CardTypes.MasterCard ||
                    CardType == CardTypes.Visa)
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
