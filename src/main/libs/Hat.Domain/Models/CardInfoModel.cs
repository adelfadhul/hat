using Hat.Domain.Constants;
using Hat.Domain.Helpers;

namespace Hat.Domain.Models
{
    public class CardInfoModel
    {
        #region data
        public string? CardNumber { get; set; }
        public string? NameOnCard { get; set; }
        public string? CardValidationCode { get; set; }
        public string? ExpirationDate { get; set; }

        public bool IsSelected { get;set; }

        #endregion

        #region rich
        public string CardType
        {
            get
            {
                var normalizedCardNumber = CardNumber?.Replace("-", string.Empty);
                if (CreditCardTypeRegexHelper.AmericanExpress.IsMatch(normalizedCardNumber))
                {
                    return CardTypes.AmericanExpress;
                }
                else if (CreditCardTypeRegexHelper.DinersClub.IsMatch(normalizedCardNumber))
                {
                    return CardTypes.DinersClub;
                }
                else if (CreditCardTypeRegexHelper.Discover.IsMatch(normalizedCardNumber))
                {
                    return CardTypes.Discover;
                }
                else if (CreditCardTypeRegexHelper.JCB.IsMatch(normalizedCardNumber))
                {
                    return CardTypes.JCB;
                }
                else if (CreditCardTypeRegexHelper.MasterCard.IsMatch(normalizedCardNumber))
                {
                    return CardTypes.MasterCard;
                }
                else if (CreditCardTypeRegexHelper.Visa.IsMatch(normalizedCardNumber))
                {
                    return CardTypes.Visa;
                }
                else
                {
                    return CardTypes.Unknown;
                }
            }
        }

      
        public string MaskedCardNumber
        {
            get
            {
                if (string.IsNullOrEmpty(CardNumber) || CardNumber.Length < 4)
                {
                    return "**** **** **** ****";
                }

                var normalizedCardNumber = CardNumber.Replace("-", string.Empty).Replace(" ", string.Empty);
                var lastFourDigits = normalizedCardNumber[^4..];
                return $"**** **** **** {lastFourDigits}";
            }
        }
        #endregion

    }
}
