using System;

namespace CARTER.Models.Stripe
{
    public class PaymentLinkModel
    {
        public Guid Id { get; set; }
        public string StripeId { get; set; }
        public string Url { get; set; }
        public PriceModel Price { get; set; }
        public bool IsTrial { get; set; }
    }
}
