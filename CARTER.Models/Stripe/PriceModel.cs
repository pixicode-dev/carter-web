namespace CARTER.Models.Stripe
{
    public class PriceModel
    {
        public int Id { get; set; }
        public ProductModel Product { get; set; }
        public string Currency { get; set; }
        public string RecurringInterval { get; set; }
        public long? RecurringIntervalCount { get; set; }
        public string RecurringUsageType { get; set; }
        public decimal? UnitAmountDecimal { get; set; }
        public string StripeId { get; set; }

    }
}
