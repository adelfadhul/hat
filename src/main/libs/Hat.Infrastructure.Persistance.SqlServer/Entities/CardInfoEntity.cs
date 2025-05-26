namespace Hat.Infrastructure.Persistance.SqlServer.Entities
{
    public class CardInfoEntity
    {
        #region data
        public Guid Id { get; set; }
        public string? CardNumber { get; set; }
        public string? NameOnCard { get; set; }
        public string? CardValidationCode { get; set; }
        public string? ExpirationDate { get; set; }

        public bool IsSelected { get;set; }

        #endregion

        

    }
}
