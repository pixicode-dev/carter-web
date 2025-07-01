using CARTER.Models.Common;
using CARTER.Models.Stripe;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CARTER.ApiIntegration.Stripe
{
    public class StripeApiClient : BaseApiClient, IStripeApiClient
    {

        public StripeApiClient(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IOptions<ApiSettingModel> apiSettings
            ) : base(httpClientFactory, httpContextAccessor, apiSettings)
        {
        }

        public async Task<ApiResult<List<PaymentLinkModel>>> GetPaymentLinks(Guid appUserId)
        {
            var result = await GetAsync<ApiResult<List<PaymentLinkModel>>>(
                $"/api/stripe/paymentlinks/{appUserId}");

            return result;
        }
        public async Task<ApiResult<List<PaymentLinkModel>>> SendPaymentLinks(Guid appUserId)
        {
            return await PostByBodyAsync<ApiResult<List<PaymentLinkModel>>, string>($"/api/stripe/paymentlinks/{appUserId}", "");

        }

    }
}
