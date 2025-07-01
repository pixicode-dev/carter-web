using CARTER.Models.Common;
using CARTER.Models.Stripe;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CARTER.ApiIntegration.Stripe
{
    public interface IStripeApiClient
    {
        Task<ApiResult<List<PaymentLinkModel>>> GetPaymentLinks(Guid appUserId);
        Task<ApiResult<List<PaymentLinkModel>>> SendPaymentLinks(Guid appUserId);
    }
}
