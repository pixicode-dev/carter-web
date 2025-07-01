namespace CARTER.Models.Stripe
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string StripeId { get; set; }
        public int? Accounts { get; set; }
    }
}
