using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venly.Model;
using Venly.Model.Enums;
using Venly.Model.Requests;
using Venly.Model.Response;

namespace Venly.Handler
{
    public class SwapHandler: VenlyAPIClientBase
    {
        SwapHandler(string accessToken, VenlyEnvironmentConfig cfg) : base(accessToken, cfg) {}

        /// <summary>
        /// Fetch a list of available token pairs
        /// GET https://api.arkane.network/api/wallets/:walletId/swaps/pairs
        /// </summary>
        /// <see href="https://docs.venly.io/api/api-products/wallet-api/swaps/list-token-pairs">Read more</see>
        public async Task<VenlyResponseBase<SwapInfoResponse>?> GetAvailablePairs(string walletId)
        {
            return await this.GetAsync<SwapInfoResponse>($"/wallets/{walletId}/swaps/pairs");
        }


        /// <summary>
        /// Endpoint to gather detailed information about a potential swap
        /// GET https://api.arkane.network/api/swaps/rates?fromSecretType=MATIC
        /// &toSecretType=MATIC&fromToken=0xeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
        /// &toToken=0x348e62131fce2f4e0d5ead3fe1719bc039b380a9
        /// &amount=1
        /// &orderType=SELL
        /// </summary>
        /// <see href="https://docs.venly.io/api/api-products/wallet-api/swaps/retrieve-exchange-rate">Read more</see>
        public async Task<VenlyResponseBase<RateResponse>?> GetExchangeRates(string walletId, 
            SecretType secretType, 
            SecretType toSecretType, 
            string fromToken, 
            string toToken, 
            int amount, 
            string orderType)
        {
            return await this.GetAsync<RateResponse>($"/wallet/{walletId}/swaps/rates" +
                $"?fromSecretType={secretType}" +
                $"&toSecretType={toSecretType}" +
                $"&fromToken={fromToken}" +
                $"&toToken={toToken}" +
                $"&amount={amount}" +
                $"&orderType={orderType}");
        }





    }
}
