namespace Hat.Domain.Models
{


    public class WishModel:IUserModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }
    }
}
